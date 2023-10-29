function initTasks() {
    tasks = document.querySelectorAll('.tg_task');

    if (!tasks || tasks.length === 0) return;

    for (var i = 0; i < tasks.length; i++) {
        tasks[i].id = 'task' + i;
        tasks[i].addEventListener('click', taskClicked);
        tasks[i].classList.add('tg_taskctrl');
        tasks[i].classList.add('tg_neutral');
        tasks[i].innerText = '';

        var succ = document.createElement('span');
        succ.innerText = 0;
        succ.classList.add('tg_success-count');

        var fail = document.createElement('span');
        fail.innerText = 0;
        fail.classList.add('tg_fail-count');

        var stat = document.createElement('span');
        stat.classList.add('tg_neutral');

        var cnt = document.createElement('span');
        cnt.classList.add('tg_cnt');
        cnt.innerText = `#${(i + 1)}`;
        tasks[i].appendChild(cnt);

        var sm = document.createElement('span');
        sm.innerText = '✓';
        tasks[i].appendChild(sm);

        var fm = document.createElement('span');
        fm.innerText = '?';
        tasks[i].appendChild(fm);
    }
}

function taskClicked(e) {
    let task = e.target;
    if (!task.id) {
        task = task.parentNode;
    }

    if (task.classList.contains('tg_neutral')) {
        task.classList.remove('tg_neutral');
        task.classList.add('tg_success');
    } else if (task.classList.contains('tg_success')) {
        task.classList.remove('tg_success');
        task.classList.add('tg_fail');
    } else if (task.classList.contains('tg_fail')) {
        task.classList.remove('tg_fail');
        task.classList.add('tg_neutral');
    }
}

initTasks();

$('.collapse').on('show.bs.collapse', function (e) {
    var id = e.target.id;
    var selector = 'a[href="#' + id + '"]';
    var i = $(selector).find('i');
    if (!i || i.length == 0) {
        return;
    }

    i[0].classList.remove('fa-circle-arrow-down');
    i[0].classList.add('fa-circle-arrow-up');
});

$('.collapse').on('hide.bs.collapse', function (e) {
    var id = e.target.id;
    var selector = 'a[href="#' + id + '"]';
    var i = $(selector).find('i');
    if (!i || i.length == 0) {
        return;
    }

    i[0].classList.remove('fa-circle-arrow-up');
    i[0].classList.add('fa-circle-arrow-down');
});