let timeout = null;
let lastUpdated = 0;
function loadStations() {
    console.log("Loading stations...");
    const search = document.getElementById("searchBox").value;
    const status = document.getElementById("status").value;

    fetch(`/AdminStation/Filter?search=${search}&status=${status}`)
        .then(res => res.text())
        .then(html => {
            document.getElementById("stationTable").innerHTML = html;
        });
}
function checkUpdate() {
    fetch('/AdminStation/CheckUpdate')
        .then(res => res.json())
        .then(data => {
            if (data.lastUpdated != lastUpdated) {
                lastUpdated = data.lastUpdated;
                loadStations();
            }
        });
}

setInterval(checkUpdate, 3000);
loadStations();

document.getElementById("searchBox").addEventListener("input", function () {
    clearTimeout(timeout);
    timeout = setTimeout(loadStations, 300);
});

document.getElementById("status").addEventListener("change", loadStations);