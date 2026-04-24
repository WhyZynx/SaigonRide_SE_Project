let timeout = null;

function getFilters() {
    return {
        search: document.getElementById("searchBox").value,
        vehicleType: document.getElementById("vehicleType").value,
        status: document.getElementById("status").value
    };
}

function loadVehicles() {
    const f = getFilters();

    fetch(`/AdminVehicle/Filter?search=${f.search}&vehicleType=${f.vehicleType}&status=${f.status}`)
        .then(res => res.text())
        .then(html => {
            document.getElementById("vehicleTable").innerHTML = html;
        });
}

// 🔥 REALTIME SEARCH (debounce chuẩn)
document.getElementById("searchBox").addEventListener("input", function () {
    clearTimeout(timeout);
    timeout = setTimeout(loadVehicles, 250);
});

// 🔥 FILTER REALTIME (KHÔNG RESET, CHẠY NGAY)
document.getElementById("vehicleType").addEventListener("change", loadVehicles);
document.getElementById("status").addEventListener("change", loadVehicles);