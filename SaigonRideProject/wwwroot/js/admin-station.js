let timeout = null;

function loadStations() {
    const search = document.getElementById("searchBox").value;
    const status = document.getElementById("status").value;

    fetch(`/AdminStation/Filter?search=${search}&status=${status}`)
        .then(res => res.text())
        .then(html => {
            document.getElementById("stationTable").innerHTML = html;
        });
}

// debounce search
document.getElementById("searchBox").addEventListener("input", function () {
    clearTimeout(timeout);
    timeout = setTimeout(loadStations, 300);
});

// filter change
document.getElementById("status").addEventListener("change", loadStations);