function deeplinkConversation(conversationId) {
    microsoftTeams.app.openLink(`https://teams.microsoft.com/l/message/19:ynb7dTln_Fs7uU3OPXjK7vPWbrM4RyCCxmtNihK3JNk1@thread.tacv2/${conversationId}?tenantId=0a762334-919f-4831-b0f3-da9eebf91cd4&groupId=d4da6b79-f72f-4501-a96b-1b9cdbba5fc1&parentMessageId=${conversationId}&teamName=Szoftver%20Fejleszt%C3%A9s%202&channelName=General&createdTime=${conversationId}`);
}

microsoftTeams.app.initialize();