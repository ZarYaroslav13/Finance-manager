// Write your Javascript code.


async function setCultureCookie(languageCode) {
    await fetch('https://localhost:5066/localization/set-culture', {
        method: 'POST',
        credentials: 'include',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(languageCode)
    });
}