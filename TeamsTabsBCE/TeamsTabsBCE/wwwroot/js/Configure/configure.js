microsoftTeams.app.initialize();

function SelectPage(pageName) {
    
    microsoftTeams.pages.config.registerOnSaveHandler((saveEvent) => {
        microsoftTeams.pages.config.setConfig({
            websiteUrl: `${window.location.origin}`,
            contentUrl: `${window.location.origin}/${pageName}`,
            entityId: pageName,
            suggestedDisplayName: pageName,
            removeUrl: ""
        });

        saveEvent.notifySuccess();
    });    

    $("#selected-page").text(pageName);

    microsoftTeams.pages.config.setValidityState(true);
}