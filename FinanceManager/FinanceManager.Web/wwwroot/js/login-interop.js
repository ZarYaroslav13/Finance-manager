async function loginUser(email, password) {
    const response = await fetch('https://localhost:5066/authentication/login', {
    method: 'POST',
credentials: 'include',
headers: {
    'Content-Type': 'application/json'
        },
body: JSON.stringify({
    email: email,
password: password
        })
    });

if (response.ok) {
    console.log("Login successful!");
window.location.href = '/home'; 
    } else {
        const error = await response.text();
alert("Login failed: " + error);
    }
}