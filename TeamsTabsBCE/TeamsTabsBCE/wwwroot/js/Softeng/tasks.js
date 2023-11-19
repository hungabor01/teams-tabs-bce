function getTaskResults() {
    microsoftTeams.app.initialize().then(() => {
        var authTokenRequest = {
            successCallback: function (token) {
                fetch('/softeng/GetTaskResults', {
                    method: 'get',
                    headers: {
                        'Content-Type': 'application/json',
                        'Authorization': 'Bearer ' + token
                    },
                    cache: 'default'
                })
                .then((response) => {
                    if (response.status === 200) {
                        return response.json();
                    } else {
                        console.log('Getting task results has failed: ' + response.status + ' ' + response.error);
                    }
                })
                .then((taskResults) => {
                    createTasks(taskResults);
                });
            },
            failureCallback: function (error) { console.log('Error getting token: ' + error); }
        };
        microsoftTeams.authentication.getAuthToken(authTokenRequest);
    });
}

function createTasks(taskResults) {
    tasks = document.querySelectorAll('.tg-task');

    if (!tasks || tasks.length === 0) return;

    for (var i = 0; i < tasks.length; i++) {
        tasks[i].addEventListener('click', taskClicked);
        tasks[i].classList.add('tg-taskctrl');        
        tasks[i].innerText = '';

        var neutral = document.createElement('span');
        var step = extractTaskNumber('step', tasks[i].id);
        neutral.innerText = `#${step}`;
        tasks[i].appendChild(neutral);

        var success = document.createElement('span');
        success.innerText = '✓';
        tasks[i].appendChild(success);

        var fail = document.createElement('span');
        fail.innerText = '?';
        tasks[i].appendChild(fail);
              
        setTaskInitialState(taskResults, tasks[i]);
    }
}

function setTaskInitialState(taskResults, task) {
    var taskResult = taskResults.find(tr => tr.taskIdentifierModel.value == task.id);
    if (taskResult != null) {
        switch (taskResult.result) {
            case 1:
                task.classList.add('tg-success');
                break;
            case 0:
                task.classList.add('tg-neutral');
                break;
            case -1:
                task.classList.add('tg-fail');
                break;
        }
    } else {
        task.classList.add('tg-neutral');
    }
}

function taskClicked(e) {
    var task = e.target;
    if (!task.id) {
        task = task.parentNode;
    }

    var result;
    if (task.classList.contains('tg-neutral')) {
        task.classList.remove('tg-neutral');
        task.classList.add('tg-success');
        result = 1;
    } else if (task.classList.contains('tg-success')) {
        task.classList.remove('tg-success');
        task.classList.add('tg-fail');
        result = -1;
    } else if (task.classList.contains('tg-fail')) {
        task.classList.remove('tg-fail');
        task.classList.add('tg-neutral');
        result = 0;
    }
    
    postResult(task.id, result);
}

function postResult(taskId, result) {
    var authTokenRequest = {
        successCallback: function (token) {
            fetch('/softeng/StoreTaskResult', {
                method: 'post',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': 'Bearer ' + token
                },
                cache: 'default',
                body: JSON.stringify(taskId + ' ' + result)
            })
            .then((response) => {
                if (response.ok) {
                    console.log('Result was sent successfully.');
                } else {
                    console.log('Result was sent unsuccessfully: ' + response.error);
                }
            });
        },
        failureCallback: function (error) { console.log('Error getting token: ' + error); }
    };
    microsoftTeams.authentication.getAuthToken(authTokenRequest);
}

getTaskResults();