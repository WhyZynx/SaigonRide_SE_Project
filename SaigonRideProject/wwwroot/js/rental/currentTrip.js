let start = new Date(window.startTime);
let price = window.price;
let stations = window.stations;

let cost = 0;
let timer;

function run() {

    timer = setInterval(() => {

        let now = new Date();
        let diff = Math.floor((now - start) / 1000);

        if (diff < 0) diff = 0;

        let h = Math.floor(diff / 3600);
        let m = Math.floor((diff % 3600) / 60);
        let s = diff % 60;

        cost = (diff / 60) * price;

        document.getElementById("timer").innerText =
            `${String(h).padStart(2, '0')}:${String(m).padStart(2, '0')}:${String(s).padStart(2, '0')}`;

        document.getElementById("cost").innerText =
            Math.round(cost).toLocaleString('vi-VN') + " VND";

    }, 1000);
}

function discount(stationId) {

    let s = stations.find(x => x.id == stationId);
    if (!s) return 0;

    let ratio = s.currentCount / s.capacity;

    return ratio < 0.2 ? 0.15 : 0;
}

function openBill() {

    clearInterval(timer);

    let stationId = document.getElementById("returnStation").value;

    let d = discount(stationId);
    let final = cost * (1 - d);

    document.getElementById("rs").value = stationId;
    document.getElementById("amount").value = Math.round(final);

    document.getElementById("bill").innerHTML = `
        <p>Original: ${Math.round(cost).toLocaleString('vi-VN')} VND</p>
        <p>Discount: ${d * 100}%</p>
        <h5>Total: ${Math.round(final).toLocaleString('vi-VN')} VND</h5>
    `;

    new bootstrap.Modal(document.getElementById("billModal")).show();
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
    run();
    initMap();
};