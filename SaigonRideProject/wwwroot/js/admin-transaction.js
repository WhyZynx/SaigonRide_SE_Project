let timeout = null;

function loadTransactions() {
    const search = document.getElementById("searchBox").value;
    const type = document.getElementById("type").value;

    document.getElementById("loading").style.display = "block";

    fetch(`/AdminTransaction/Filter?search=${search}&type=${type}`)
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