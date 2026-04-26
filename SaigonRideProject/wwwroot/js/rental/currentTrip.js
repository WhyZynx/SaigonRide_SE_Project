let start = new Date(window.startTime).getTime();
let price = window.price;
let stations = window.stations;

let timer;

function run() {

    timer = setInterval(() => {

        let now = new Date();
        let diff = Math.max(0, Math.floor((now.getTime() - start) / 1000));

        let h = Math.floor(diff / 3600);
        let m = Math.floor((diff % 3600) / 60);
        let s = diff % 60;

        let estimatedCost = (diff / 60) * price;

        document.getElementById("timer").innerText =
            `${String(h).padStart(2, '0')}:${String(m).padStart(2, '0')}:${String(s).padStart(2, '0')}`;

        document.getElementById("estimated").innerText =
            "Estimated: " + Math.round(estimatedCost).toLocaleString('vi-VN') + " VND";

    }, 1000);
}
let isEnded = false;

function openBill() {

    clearInterval(timer);

    let stationId = document.getElementById("returnStation")?.value;

    let endTime = new Date();

    let diff = Math.max(0, Math.floor((endTime - start) / 1000));

    window.finalDurationSeconds = diff;

    let finalCost = (diff / 60) * price;

    document.getElementById("rs").value = stationId;
    document.getElementById("pm").value = "";

    document.getElementById("durationSeconds").value = diff;

    document.getElementById("bill").innerHTML = `
        <p>Duration: ${diff} seconds</p>
        <h5>Total: ${Math.round(finalCost).toLocaleString('vi-VN')} VND</h5>
    `;

    let modal = document.getElementById("billModal");
    if (modal) {
        new bootstrap.Modal(modal).show();
    }
}

function confirmPay() {

    let method = document.getElementById("paymentMethod").value;

    if (!confirm("Confirm payment?")) return;

    document.getElementById("pm").value = method;

    document.getElementById("form").submit();
}

function initMap() {

    let map = L.map('map').setView([10.77, 106.69], 13);

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png')
        .addTo(map);

    stations.forEach(s => {

        L.marker([s.latitude, s.longitude])
            .addTo(map)
            .bindPopup(`${s.name} (${s.currentCount}/${s.capacity})`);

    });
}

window.onload = function () {

    if (!window.startTime || !window.price) {
        console.error("Missing rental data");
        return;
    }

    run();
    initMap();
};