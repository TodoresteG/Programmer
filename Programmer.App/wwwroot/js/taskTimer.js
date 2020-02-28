const isActive = document.getElementById('is-active').textContent.toLowerCase();

if (isActive === 'true') {
    const taskTimer = document.getElementById('task');
    taskTimer.parentElement.className = 'nav-item mx-0 mx-lg-1 visible';

    let endTime = cookieCheck();
    initializeClock('task-timer', endTime);
}

function cookieCheck() {
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

function getTimeRemaining(endTime) {
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

function initializeClock(id, endTime) {
    let clock = document.getElementById(id);
    let hoursSpan = document.querySelector('.task-hours');
    let minutesSpan = document.querySelector('.task-minutes');
    let secondsSpan = document.querySelector('.task-seconds');

    function updateClock() {
        let time = getTimeRemaining(endTime);

        hoursSpan.textContent = ('0' + time.hours).slice(-2) + 'h:';
        minutesSpan.textContent = ('0' + time.minutes).slice(-2) + 'm:';
        secondsSpan.textContent = ('0' + time.seconds).slice(-2) + 's';

        if (time.total <= 0) {
            clearInterval(timeInterval);

            $.ajax({
                method: 'GET',
                url: '/api/users/UpdateUserStats'
            })
                .done(function success(data) {
                    const taskTimer = document.getElementById('task');
                    taskTimer.parentElement.className = 'invisible';

                    document.getElementById('level').textContent = data.level;
                    document.getElementById('xp').textContent = data.xp;
                    document.getElementById('xp-for-next').textContent = data.xpForNextLevel;
                    document.getElementById(data.hardSkillName).textContent = data.hardSkill;
                    document.getElementById(data.softSkillName).textContent = data.softSkill;
                })
                .fail(function fail(data, status) {
                    alert('I have task failed you');
                    console.log(data);
                    console.log(status);
                });
        }
    }

    updateClock();
    let timeInterval = setInterval(updateClock, 1000);
}
