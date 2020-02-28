let currentEnergy = parseInt(document.getElementById('energy').textContent);
let endTime = cookieCheck();

initializeClock('energy-timer', endTime);

function cookieCheck() {
    let endTime;

    if (document.cookie && document.cookie.match('energyClock')) {
        endTime = document.cookie.match(/(^|;)energyClock=([^;]+)/)[2];
    }
    else {
        endTime = addMinutes(new Date(), 2).toUTCString();
        document.cookie = 'energyClock=' + endTime + '; path=/; expires=' + endTime + ';';
    }

    return endTime;
}

function resetTimer() {
    let endTime = cookieCheck();
    initializeClock('energy-timer', endTime);
}

function addMinutes(date, minutes) {
    return new Date(date.getTime() + minutes * 60000);
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
    let minutesSpan = document.querySelector('.energy-minutes');
    let secondsSpan = document.querySelector('.energy-seconds');

    function updateClock() {
        let time = getTimeRemaining(endTime);

        minutesSpan.textContent = ('0' + time.minutes).slice(-2) + 'm:';
        secondsSpan.textContent = ('0' + time.seconds).slice(-2) + 's';

        if (currentEnergy === 30) {
            document.cookie.match('energyClock') = null;
            document.getElementById('energy-timer').innerHTML = '';
            return;
        }

        if (time.total <= 0) {
            clearInterval(timeInterval);

            $.ajax({
                method: 'GET',
                url: '/api/users/UpdateUserEnergy'
            })
                .done(function success(data) {
                    $('#energy').text(data);
                    currentEnergy++;
                    resetTimer();
                })
                .fail(function fail(data, status) {
                    alert('I have failed you');
                    console.log(data);
                    console.log(status);
                });
        }
    }

    updateClock();
    let timeInterval = setInterval(updateClock, 1000);
}