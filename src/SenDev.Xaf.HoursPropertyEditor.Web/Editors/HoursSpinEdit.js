function convertHours(inputString) {
    return Math.round(convertHoursCore(inputString) * 100) / 100;
}
function convertHoursCore(inputString) {
    time = inputString.replace(/\s/g, '');		// clear spaces

    var reg1 = /^(\d+)([hsm])$/;		// 10h 10s 10m
    var reg2 = /^(\d+)[hs](\d+)m$/;		// 10h10m 10s10m
    var reg3 = /^(\d+)([,:])(\d+)$/;	// 10:10 10,10
    var reg4 = /^(\d+)$/;				// 10

    if (reg1.test(time)) {
        var res1 = reg1.exec(time);
        if (res1[2] === "m") {
            return parseInt(res1[1]) / 60;
        } else {
            return parseInt(res1[1]);
        }
    } else if (reg2.test(time)) {
        var res2 = reg2.exec(time);
        return parseInt(res2[1]) + parseInt(res2[2]) / 60;
    } else if (reg3.test(time)) {
        var res3 = reg3.exec(time);
        if (res3[2] === ":") {
            return parseInt(res3[1]) + parseInt(res3[3]) / 60;
        } else {
            return parseFloat(res3[1] + "." + res3[3]);
        }
    } else if (reg4.test(time)) {
        var res4 = reg4.exec(time);
        return parseInt(res4[1]);
    } else {
        throw new Error("Time " + inputString + " is not correct");
    }
}
