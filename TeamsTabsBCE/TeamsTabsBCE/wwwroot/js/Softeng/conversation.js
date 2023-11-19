function startConversation(taskId, listName) {
    var authTokenRequest = {
        successCallback: function (token) {
            fetch('/softeng/GetConversationId?' + new URLSearchParams({ taskIdentifierValue: taskId }), {
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
                } else if (response.status === 204) {
                    createConversation(taskId, listName);
                }
                else {
                    console.log('Getting conversation id has failed: ' + response.status + ' ' + response.error);
                }
            })
            .then((conversationId) => {
                continueConversation(taskId, listName, conversationId);
            });
        },
        failureCallback: function (error) { console.log('Error getting token: ' + error); }
    };
    microsoftTeams.authentication.getAuthToken(authTokenRequest);
}

function createConversation(taskId, listName) {
    microsoftTeams.app.getContext().then((context) => {
        microsoftTeams.conversations.openConversation(
            {
                'subEntityId': taskId,
                'entityId': context.page.id,
                'channelId': context.channel.id,
                'title': getConversationTitle(taskId, listName),
                'onStartConversation': (conversationResponse) => onStartConversation(taskId, conversationResponse)
            }
        );
    });
}

function onStartConversation(taskId, conversationResponse) {
    var authTokenRequest = {
        successCallback: function (token) {
            fetch('/softeng/StoreConversation', {
                method: 'post',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': 'Bearer ' + token
                },
                cache: 'default',
                body: JSON.stringify(taskId + ' ' + conversationResponse.conversationId)
            })
            .then((response) => {
                if (response.ok) {
                    console.log('Conversation id was sent successfully.');
                } else {
                    console.log('Conversation id was sent unsuccessfully.' + response.error);
                }
            });
        },
        failureCallback: function (error) { console.log('Error getting token: ' + error); }
    };
    microsoftTeams.authentication.getAuthToken(authTokenRequest);
}

function continueConversation(taskId, listName, conversationId) {
    microsoftTeams.app.getContext().then((context) => {
        microsoftTeams.conversations.openConversation(
            {
                'subEntityId': taskId,
                'entityId': context.page.id,
                'channelId': context.channel.id,
                'title': getConversationTitle(taskId, listName),
                'conversationId': conversationId
            }
        );
    });
}

function getConversationTitle(taskId, listName) {
    var week = extractTaskNumber('week', taskId);
    var step = extractTaskNumber('step', taskId);
    
    return `${week}. hét: ${listName}/${step}`;
}