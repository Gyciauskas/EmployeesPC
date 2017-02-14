// call a JavaScript function once the page has loaded 
//window.onload = function () {
//    myFunction(@Model.SalaryOnHands);
//};

function myFunction(netSalary) {
    //
    var grossSalary;
    var mmaWage = 380;
    var baseNPD = 310;
    var incomeTax = 0.15;
    var healthInsurance = 0.06;
    var pensionInsurance = 0.03;
    var employerTax = 0.3118;
    var npd = 0;

    if (netSalary == null) {
        return;
    }

    if (netSalary <= 335.3) {
        grossSalary = (netSalary - 46.5) / (1 - (incomeTax + healthInsurance + pensionInsurance));
        npd = baseNPD;
    }
    else if (netSalary < 760) {
        grossSalary = (netSalary - 75) / (1 - ((incomeTax * 1.5) + healthInsurance + pensionInsurance));
        npd = baseNPD - 0.5 * (grossSalary - mmaWage);
    }
    else {
        grossSalary = netSalary / (1 - (incomeTax + healthInsurance + pensionInsurance));
        npd = 0;
    }

    document.getElementById("netSalary").innerHTML = x.toFixed(2) + " €";
    document.getElementById("grossSalary").innerHTML = grossSalary.toFixed(2) + " €";
    document.getElementById("fullCost").innerHTML = (grossSalary + (grossSalary * employerTax)).toFixed(2) + " €";

    document.getElementById("employerTax").innerHTML = (grossSalary * employerTax).toFixed(2) + " €";
    //
    document.getElementById("incomeTax").innerHTML = ((grossSalary - npd) * incomeTax).toFixed(2) + " €";
    document.getElementById("healthInsurance").innerHTML = (grossSalary * healthInsurance).toFixed(2) + " €";
    document.getElementById("pensionInsurance").innerHTML = (grossSalary * pensionInsurance).toFixed(2) + " €";
    document.getElementById("npd").innerHTML = npd.toFixed(2) + " €";
}