// Hàm này cập nhật ảnh khi người dùng chọn file
function updateImagePreview(fileInputId, previewImgId) {
    var fileInput = document.getElementById(fileInputId); // Lấy đối tượng FileUpload từ ID
    var file = fileInput.files[0]; // Lấy tệp đầu tiên

    if (file) {
        var reader = new FileReader(); // FileReader giúp đọc ảnh từ file
        reader.onload = function (e) {
            // Khi ảnh đã được đọc, cập nhật đường dẫn vào thẻ <img> để hiển thị
            document.getElementById(previewImgId).src = e.target.result;
        }
        reader.readAsDataURL(file); // Đọc file dưới dạng Data URL để hiển thị ảnh
    }
}

// Đảm bảo khi trang tải xong, gán sự kiện onchange cho file input
window.onload = function () {
    // Gán sự kiện onchange cho file input 1
    document.getElementById('<%= file_up1.ClientID %>').onchange = function () {
        updateImagePreview('<%= file_up1.ClientID %>', 'imgPreview1');
    };

    // Gán sự kiện onchange cho file input 2
    document.getElementById('<%= file_up2.ClientID %>').onchange = function () {
        updateImagePreview('<%= file_up2.ClientID %>', 'imgPreview2');
    };

    // Gán sự kiện onchange cho file input 3
    document.getElementById('<%= file_up3.ClientID %>').onchange = function () {
        updateImagePreview('<%= file_up3.ClientID %>', 'imgPreview3');
    };
};
