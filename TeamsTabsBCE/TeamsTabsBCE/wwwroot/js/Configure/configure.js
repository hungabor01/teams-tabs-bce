microsoftTeams.app.initialize();

function SelectPage(pageName) {

    sendSettings();

    microsoftTeams.pages.config.registerOnSaveHandler((saveEvent) => {
        microsoftTeams.pages.config.setConfig({
            websiteUrl: `${window.location.origin}`,
            contentUrl: `${window.location.origin}/${pageName}`,
            entityId: pageName,
            suggestedDisplayName: pageName,
            removeUrl: ''
        });

        saveEvent.notifySuccess();
    });    

    $('#selected-page').text(pageName);

    microsoftTeams.pages.config.setValidityState(true);
}

function sendSettings() {
    var authTokenRequest = {
        successCallback: function (token) {
            microsoftTeams.app.getContext().then((context) => {
                fetch('/configure/StoreSettings', {
                    method: 'post',
                    headers: {
                        'Content-Type': 'application/json',
                        'Authorization': 'Bearer ' + token
                    },
                    cache: 'default',
                    body: JSON.stringify({
                        channelId: context.channel.id,
                        tenantId: context.user.tenant.id,
                        groupId: context.team.groupId,
                        groupName: context.team.displayName
                    })
                })
                .then((response) => {
                    if (response.ok) {
                        console.log('Result was sent successfully.');
                    } else {
                        console.log('Result was sent unsuccessfully: ' + response.error);
                    }
                });
            });
        },
        failureCallback: function (error) { console.log('Error getting token: ' + error); }
    };
    microsoftTeams.authentication.getAuthToken(authTokenRequest);
}