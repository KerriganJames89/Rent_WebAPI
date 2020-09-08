var app = angular.module("Bills", ["ngRoute"]);
app.controller('mainCtrl', function ($scope, $http) {

    $http({
        method: 'GET',
        url: 'api/Bill/Get'
    }).then(function success(response) {
        $scope.bills = response.data;
        console.log(response.data);
    }, function failure() {

    });

    /*
    $http({
        method: 'POST',
        url: 'api/Semester/AddOrUpdate',
        data: $scope.selectedSemester
    }).then(function success(response) {
        $scope.semesters.push(response.data);
    }, function failure() {

    });

    $http({
        method: 'GET',
        url:'api/Semester/GetById/'
    }).then(function success(response) {
        $scope.selectedSemester = response.data;
    }, function failure() {

    });

    /*
    $scope.bills =
        [
            { 'name': 'Bob', 'amount': '300' },
            { 'name': 'Kelley', 'amount': '500' },
            { 'name': 'Tim', 'amount': '200' }
        ];*/

    /*
    console.log(billData);
    $scope.addBills = function (billData) {
        $scope.bills = billData;
    }*/

    // GET VALUES FROM INPUT BOXES AND ADD A NEW ROW TO THE TABLE.
    $scope.addRow = function () {
        if ($scope.Name != undefined && $scope.Amount != undefined) {
            var bill = new Object();
            var update = -1;
            //var lastBill = $scope.bills.length - 1;
            ///bill.Id = lastBill.Id + 1;
            bill.Name = $scope.Name;
            bill.Amount = $scope.Amount;

            for (i = 0; i < $scope.bills.length; i++) {
                if ($scope.bills[i].Name == bill.Name) {
                    bill.Id = $scope.bills[i].Id
                    update = i;
                    break;

                }
            }

            console.log(bill)

            $http({
                method: 'POST',
                url: 'api/Bill/AddOrUpdate',
                data: bill
            }).then(function success(response) {
                //response.data.Id = lastBill
                if (update != -1) {
                    $scope.bills[i] = response.data;
                }

                else {
                    $scope.bills.push(response.data);
                }

            }, function failure() {

            });

            // CLEAR TEXTBOX.
            $scope.Name = null;
            $scope.Amount = null;
        }
    };

    // REMOVE SELECTED ROW(s) FROM TABLE.
    $scope.removeRow = function () {
        var removeBills = [];
        var remainingBills = [];
        angular.forEach($scope.bills, function (value) {
            if (!value.Remove) {
                remainingBills.push(value);
            }

            else removeBills.push(value.Id);
        });
        console.log(removeBills)

        for (i = 0; i < removeBills.length; i++)
        {
            console.log(removeBills[i])
            $http({
                method: 'GET',
                url: 'api/Bill/RemoveById/' + removeBills[i],
            }).then(
                function success(response) {
                    console.log(remainingBills)
                    $scope.bills = remainingBills;
                }, function failure() {

                });
            };
        }
});
