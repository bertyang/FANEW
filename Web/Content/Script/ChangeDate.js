function ChangeDateFormat(val, Format) {
    if (val != null) {
        var date = new Date(parseInt(val.replace("/Date(", "").replace(")/", ""), 10));
        var month = date.getMonth() + 1 < 10 ? "0" + (date.getMonth() + 1) : date.getMonth() + 1;
        var currentDate = date.getDate() < 10 ? "0" + date.getDate() : date.getDate();
        if (Format == "yyyy-MM-dd HH:mm:ss") {
            var Hours = date.getHours();
            if (Hours < 10) {
                Hours = "0" + Hours;
            }
            var Minutes = date.getMinutes();
            if (Minutes < 10) {
                Minutes = "0" + Minutes;
            }
            var getSeconds = date.getSeconds();
            if (getSeconds < 10) {
                getSeconds = "0" + getSeconds;
            }
            return date.getFullYear() + "-" + month + "-" + currentDate + " " + Hours + ":" + Minutes + ":" + getSeconds;
        }
        return date.getFullYear() + "-" + month + "-" + currentDate;
    }

    return "";
}