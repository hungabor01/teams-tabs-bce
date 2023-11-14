microsoftTeams.app.initialize().then(() => {
    var authTokenRequest = {
        successCallback: function (token) {
            console.log("Success: " + token);

            fetch('/softeng/GetUserEmail', {
                method: 'get',
                headers: {
                    "Content-Type": "application/text",
                    "Authorization": "Bearer " + token
                },
                cache: 'default'
            })
            .then((response) => {
                if (response.ok) {
                    return response.text();
                } else {
                    reject(response.error);
                }
            })
            .then((email) => {
                console.log(email);
            });
        },
        failureCallback: function (error) { console.log("Error getting token: " + error); }
    };
    microsoftTeams.authentication.getAuthToken(authTokenRequest);
});

function startConversation(id) {
    microsoftTeams.app.getContext().then((context) => {
        microsoftTeams.conversations.openConversation(
            {
                "subEntityId": id,
                "entityId": context.page.id,
                "channelId": context.channel.id,
                "title": "Beszélgetés a " + id + " témához",
                "onStartConversation": (conversationResponse) => onStartConversation(conversationResponse)
            }
        );
    });
}

function onStartConversation(conversationResponse) {
    localStorage.setItem('subEntityId', conversationResponse.subEntityId);
    localStorage.setItem('conversationId', conversationResponse.conversationId);
}

function closeConversation() {
    microsoftTeams.conversations.closeConversation();
}

// Method to continue an existing conversation.
function continueConversation(span) {
    microsoftTeams.app.getContext().then((context) => {
        microsoftTeams.conversations.openConversation(
            {
                "subEntityId": span.id,
                "entityId": context.page.id,
                "channelId": context.channel.id,
                "title": "Task Title",
                "conversationId": "1698601670774"
            }
        );
    });
}

// Method to execute deeplink to redirect to the subentity/conversation in the channel.
function deeplinkConversation() {
    microsoftTeams.app.getContext().then((context) => {
        microsoftTeams.app.openLink("https://teams.microsoft.com/l/message/" + context.channel.id + "/" + localStorage.conversationId + "?groupId=" + context.team.groupId + "&tenantId=" + context.user.tenant.id + "&parentMessageId=" + localStorage.conversationId);
    })
}