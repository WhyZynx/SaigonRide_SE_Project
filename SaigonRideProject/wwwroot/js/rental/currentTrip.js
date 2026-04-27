let selectedStation = null;
let map;

window.selectStation = function (id, name, vehicleCount, capacity) {

    if (vehicleCount >= capacity) {
        return;
    }

    selectedStation = id;

    document.getElementById("selectedStationName").innerText = name;

    document.querySelectorAll(".station-card")
        .forEach(c => c.classList.remove("border-primary"));

    document.getElementById("station-" + id)
        ?.classList.add("border-primary");
};

window.endTrip = function () {

    if (!selectedStation) {
        alert("Please select a return station");
        return;
    }

    let duration =
        Math.floor((new Date().getTime() - new Date(window.startTime).getTime()) / 1000);

    document.getElementById("rs").value = selectedStation;
    document.getElementById("durationSeconds").value = duration;

    document.getElementById("form").submit();
};

function runTimer() {

    setInterval(() => {

        let diff =
            Math.floor((new Date().getTime() - new Date(window.startTime).getTime()) / 1000);

        let m = Math.floor(diff / 60);
        let s = diff % 60;

        document.getElementById("timer").innerText =
            `${m}:${s.toString().padStart(2, '0')}`;

        let cost = (diff / 60) * window.price;

        document.getElementById("estimated").innerText =
            "Estimated: " + Math.round(cost).toLocaleString('vi-VN') + " VND";

    }, 1000);
}

function initMap() {

    map = L.map('map').setView([10.77, 106.69], 13);

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png')
        .addTo(map);

    window.stations.forEach(s => {

        let marker = L.circleMarker([s.latitude, s.longitude], {
            color: s.isLow ? "red" : "green",
            radius: 8
        }).addTo(map);

        marker.bindPopup(
            `${s.name}<br>${s.vehicleCount}/${s.capacity}`
        );

        marker.on("click", () => {
            selectStation(s.id, s.name, s.vehicleCount, s.capacity);
        });
    });
}

window.onload = function () {

    if (!window.startTime || !window.price || !window.stations) {
        console.error("Missing rental data");
        return;
    }

    runTimer();
    initMap();
};