let currentEnergy = parseInt(document.getElementById('energy').textContent);
let endTime = energyCookieCheck();

initializeEnergyClock('energy-timer', endTime);

function energyCookieCheck() {
    let endTime;

    if (document.cookie && document.cookie.match('energyClock')) {
        endTime = document.cookie.match(/energyClock=([^;]+)/)[1];
    }
    else {
        endTime = addMinutes(new Date(), 0.3).toUTCString();
        document.cookie = 'energyClock=' + endTime + '; path=/; expires=' + endTime + ';';
    }

    return endTime;
}

function resetTimer() {
    let endTime = energyCookieCheck();
    initializeEnergyClock('energy-timer', endTime);
}

function addMinutes(date, minutes) {
    return new Date(date.getTime() + minutes * 60000);
}

function getEnergyTimeRemaining(endTime) {
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

function initializeEnergyClock(id, endTime) {
    let minutesSpan = document.querySelector('.energy-minutes');
    let secondsSpan = document.querySelector('.energy-seconds');

    function updateEnergyClock() {
        let time = getEnergyTimeRemaining(endTime);

        minutesSpan.textContent = ('0' + time.minutes).slice(-2) + 'm:';
        secondsSpan.textContent = ('0' + time.seconds).slice(-2) + 's';

        if (currentEnergy >= 30) {
            document.getElementById('energy-timer').innerHTML = '';
            return;
        }

        if (time.total <= 0) {
            clearInterval(timeInterval);

            fetch('/api/users/UpdateUserEnergy')
                .then((response) => {
                    return response.json();
                })
                .then((data) => {
                    document.getElementById('energy').textContent = data;
                    currentEnergy++;
                    resetTimer();
                })
        }
    }

    updateEnergyClock();
    let timeInterval = setInterval(updateEnergyClock, 1000);
}