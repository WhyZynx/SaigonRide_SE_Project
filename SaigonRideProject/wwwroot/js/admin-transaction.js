let timeout = null;
let lastUpdated = 0;

function getFilters() {
    return {
        search: document.getElementById("searchBox").value,
        type: document.getElementById("type").value
    };
}

function loadTransactions() {
    console.log("Reload transaction table...");
    const f = getFilters();

    document.getElementById("loading").style.display = "block";

    fetch(`/AdminTransaction/Filter?search=${f.search}&type=${f.type}`)
        .then(res => res.text())
        .then(html => {
            document.getElementById("transactionTable").innerHTML = html;
            document.getElementById("loading").style.display = "none";
        });
}

document.getElementById("searchBox").addEventListener("input", function () {
    clearTimeout(timeout);
    timeout = setTimeout(loadTransactions, 300);
});

document.getElementById("type").addEventListener("change", loadTransactions);