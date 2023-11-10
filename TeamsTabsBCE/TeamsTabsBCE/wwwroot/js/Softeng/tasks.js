function initTasks() {
    tasks = document.querySelectorAll('.tg-task');

    if (!tasks || tasks.length === 0) return;

    for (var i = 0; i < tasks.length; i++) {
        tasks[i].addEventListener('click', taskClicked);
        tasks[i].classList.add('tg-taskctrl');
        tasks[i].classList.add('tg-neutral');
        tasks[i].innerText = '';

        var neutral = document.createElement('span');
        var index = tasks[i].id.split('-')[2];
        neutral.innerText = `#${index}`;
        tasks[i].appendChild(neutral);

        var success = document.createElement('span');
        success.innerText = '✓';
        tasks[i].appendChild(success);

        var fail = document.createElement('span');
        fail.innerText = '?';
        tasks[i].appendChild(fail);
    }
}

function taskClicked(e) {
    let task = e.target;
    if (!task.id) {
        task = task.parentNode;
    }

    if (task.classList.contains('tg-neutral')) {
        task.classList.remove('tg-neutral');
        task.classList.add('tg-success');
    } else if (task.classList.contains('tg-success')) {
        task.classList.remove('tg-success');
        task.classList.add('tg-fail');
    } else if (task.classList.contains('tg-fail')) {
        task.classList.remove('tg-fail');
        task.classList.add('tg-neutral');
    }
}

initTasks();