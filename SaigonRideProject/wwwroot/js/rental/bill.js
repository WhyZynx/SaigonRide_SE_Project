let paymentId = null;

function openQR(rentalId) {

    const methodEl = document.getElementById("paymentMethod");

    if (!methodEl) {
        console.error("paymentMethod element not found");
        return;
    }

    let method = methodEl.value;

    fetch("/Rental/ConfirmPayment", {
        method: "POST",
        headers: {
            "Content-Type": "application/x-www-form-urlencoded"
        },
        body: `rentalId=${rentalId}&paymentMethod=${method}`
    })
        .then(r => r.json())
        .then(data => {

            if (!data.success) {
                alert("Payment init failed");
                return;
            }

            paymentId = data.paymentId;

            document.getElementById("qrImage").src = data.qr;

            document.getElementById("qrAmount").innerText =
                Number(data.amount).toLocaleString('vi-VN') + " VND";

            new bootstrap.Modal(document.getElementById("qrModal")).show();
        });
}

function confirmPaid() {

    fetch("/Rental/CompletePayment", {
        method: "POST",
        headers: {
            "Content-Type": "application/x-www-form-urlencoded"
        },
        body: `id=${paymentId}`
    })
        .then(r => r.json())
        .then(data => {

            if (data.success) {
                window.location.href = `/Rental/PaymentSuccess?paymentId=${paymentId}`;
            } else {
                alert("Payment failed or insufficient balance");
            }
        });
}