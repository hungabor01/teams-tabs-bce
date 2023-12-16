microsoftTeams.app.initialize();

function deeplinkConversation(conversationId) {
    var authTokenRequest = {
        successCallback: function (token) {
            fetch('/softengDashboard/GetSettings', {
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
            .then((settings) => {
                microsoftTeams.app.openLink(`https://teams.microsoft.com/l/message/${settings.channelId}/${conversationId}?tenantId=${settings.tenantId}&groupId=${settings.groupId}&parentMessageId=${conversationId}&teamName=${settings.groupName}&channelName=General&createdTime=${conversationId}`);
            });
        },
        failureCallback: function (error) { console.log('Error getting token: ' + error); }
    };
    microsoftTeams.authentication.getAuthToken(authTokenRequest);


    
}
