const isActive = document.getElementById('is-active').textContent.toLowerCase();

if (isActive === 'true') {
    const taskTimer = document.getElementById('task');
    taskTimer.parentElement.className = 'nav-item mx-0 mx-lg-1 visible';

    let endTime = taskCookieCheck();
    initializeTaskClock('task-timer', endTime);
}

function taskCookieCheck() {
    let endTime;

    if (document.cookie && document.cookie.match('taskClock')) {
        endTime = document.cookie.match(/taskClock=([^;]+)/)[1];
    }
    else {
        endTime = new Date(document.getElementById('task-time').textContent).toUTCString();
        document.cookie = 'taskClock=' + endTime + '; path=/; expires=' + endTime + ';';
    }

    return endTime;
}

function getTaskTimeRemaining(endTime) {
    let time = Date.parse(endTime) - Date.parse(new Date());
    let seconds = Math.floor((time / 1000) % 60);
    let minutes = Math.floor((time / 1000 / 60) % 60);
    let hours = Math.floor(time / (1000 * 60 * 60) % 24);

    return {
        'total': time,
        'hours': hours,
        'minutes': minutes,
        'seconds': seconds,
    };
}

function getUpdatePath() {
    const taskType = document.getElementById('task-type').textContent;

    switch (taskType) {
        case 'Lecture':
            return '/api/users/UpdateUserAfterLecture';
        case 'Exam':
            return '/api/users/UpdateUserAfterExam';
        case 'Documentation':
            return '/api/users/UpdateUserAfterDocumentation'
    }
}

function initializeTaskClock(id, endTime) {
    let clock = document.getElementById(id);
    let hoursSpan = document.querySelector('.task-hours');
    let minutesSpan = document.querySelector('.task-minutes');
    let secondsSpan = document.querySelector('.task-seconds');

    function updateTaskClock() {
        let time = getTaskTimeRemaining(endTime);

        hoursSpan.textContent = ('0' + time.hours).slice(-2) + 'h:';
        minutesSpan.textContent = ('0' + time.minutes).slice(-2) + 'm:';
        secondsSpan.textContent = ('0' + time.seconds).slice(-2) + 's';

        if (time.total <= 0) {
            clearInterval(timeInterval);

            const apiPath = getUpdatePath();

            fetch(apiPath)
                .then((response) => {
                    return response.json();
                })
                .then((data) => {
                    const taskTimer = document.getElementById('task');
                    taskTimer.parentElement.className = 'invisible';

                    document.getElementById('level').textContent = data.level;
                    document.getElementById('xp').textContent = data.xp;
                    document.getElementById('xp-for-next').textContent = data.xpForNextLevel;
                    document.getElementById(data.hardSkillName).textContent = data.hardSkill;
                    document.getElementById(data.softSkillName).textContent = data.softSkill;
                })
        }
    }

    //updateClock();
    let timeInterval = setInterval(updateTaskClock, 1000);
}
