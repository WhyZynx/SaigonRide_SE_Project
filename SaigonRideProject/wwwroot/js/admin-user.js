let timeout = null;
function getFilters() {
    return {
        search: document.getElementById("searchBox").value,
        userType: document.getElementById("userType").value,
        status: document.getElementById("status").value
    };
}

function loadUsers() {
    console.log("Reload user table...");
    const f = getFilters();

    fetch(`/AdminUser/Filter?search=${f.search}&userType=${f.userType}&status=${f.status}`)
        .then(res => res.text())
        .then(html => {
            document.getElementById("userTable").innerHTML = html;
        });
}

document.getElementById("searchBox").addEventListener("input", function () {
    clearTimeout(timeout);
    timeout = setTimeout(loadUsers, 250);
});

document.getElementById("userType").addEventListener("change", loadUsers);
document.getElementById("status").addEventListener("change", loadUsers);