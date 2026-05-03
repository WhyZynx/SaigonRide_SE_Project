let timeout = null;
let lastUpdated = 0;

function getFilters() {
    return {
        search: document.getElementById("searchBox").value,
        vehicleType: document.getElementById("vehicleType").value,
        status: document.getElementById("status").value
    };
}

function loadVehicles() {
    const f = getFilters();

    console.log("Reload vehicle table...");

    fetch(`/AdminVehicle/Filter?search=${f.search}&vehicleType=${f.vehicleType}&status=${f.status}`)
        .then(res => res.text())
        .then(html => {
            document.getElementById("vehicleTable").innerHTML = html;
        });
}

document.getElementById("searchBox").addEventListener("input", function () {
    clearTimeout(timeout);
    timeout = setTimeout(loadVehicles, 250);
});

function checkUpdate() {
    fetch('/AdminVehicle/CheckUpdate')
        .then(res => res.json())
        .then(data => {
            if (lastUpdated === 0) {
                lastUpdated = data.lastUpdated;
                return;
            }

            if (data.lastUpdated != lastUpdated) {
                lastUpdated = data.lastUpdated;
                console.log("Vehicle updated → reload");
                loadVehicles();
            }
        });
}

setInterval(checkUpdate, 3000);
loadVehicles();

document.getElementById("vehicleType").addEventListener("change", loadVehicles);
document.getElementById("status").addEventListener("change", loadVehicles);