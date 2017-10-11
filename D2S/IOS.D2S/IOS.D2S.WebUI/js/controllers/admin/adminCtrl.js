(function () {
    var adminCtrl = function ($rootScope, $scope, $location, util, authorizationSvc, configs, $http) {

        util.setIsloggedIn(true);


        $scope.tabs = [
   { title: 'Dynamic Title 1', content: 'Dynamic content 1' },
   { title: 'Dynamic Title 2', content: 'Dynamic content 2', disabled: true }
        ];

        $scope.alertMe = function () {
            setTimeout(function () {
                $window.alert('You\'ve selected the alert tab!');
            });
        };

        $scope.model = {
            name: 'Tabs'
        };

       

        /* Get user list from api call */
        function getUsers() {
            //$('#preloader').show();
            var dataUrl = "http://localhost:33001/api/" + 'Auth/GetUsers?branchId=' + 12;

            $http({
                method: "GET",
                url: dataUrl
            }).success(function (data, status, headers, config) {
                //$('#preloader').hide();

                $scope.dataSet = data;
                //$scope.parentTableParams.reload();
            }).
              error(function (data, status, headers, config) {
                  //$('#preloader').hide();
                  console.log(data);
                  console.log(status);
              });
        };
        //getUsers();

        /*
        * User Save option
        * Input Param : User object
        */
        $scope.saveUserClickEvent = function () {
            hideValidations();
            if (isValidAlbumData()) {
                
                    var userObj = {
                        Id: $scope.user.Id,
                        Title: $scope.user.Title,
                        Description: $scope.user.Description,
                        BranchId: eventBus.getBranchId(),
                        IsActive: $scope.user.IsActive,
                        EventDate: $filter('date')($scope.datepicker.EventDate, "yyyy-MM-dd")
                    };

                    var popupMsg = $scope.user.Id > 0 ? "Update" : "Save";

                    //$('#preloader').show();
                    var dataUrl = configs.SERVICE_BASE_URL + 'Auth/InsertOrUpdateUser';
                    $http({
                        method: "POST",
                        url: dataUrl,
                        data: $.param(userObj),
                        headers: { 'Content-Type': 'application/x-www-form-urlencoded'}
                    }).success(function (data, status, headers, config) {

                        if (data > 0) {
                            getUsers();
                            BootstrapDialog.show({
                                type: BootstrapDialog.TYPE_SUCCESS,
                                title: 'Infromation',
                                closable: false,
                                message: "Album " + popupMsg + "d Successfully.",
                                buttons: [{
                                    label: 'Ok',
                                    action: function (dialogItself) {
                                        dialogItself.close();
                                    }
                                }]
                            });
                        } else {
                            $('#preloader').hide();
                            BootstrapDialog.show({
                                type: BootstrapDialog.TYPE_DANGER,
                                title: 'Infromation',
                                closable: false,
                                message: "Album " + popupMsg + " Fail, Please Try Again.",
                                buttons: [{
                                    label: 'Ok',
                                    action: function (dialogItself) {
                                        dialogItself.close();
                                    }
                                }]
                            });
                        }
                    }).
                    error(function (data, status, headers, config) {
                        console.log(data);
                        console.log(status);
                    });
                
            }
        };



        /*
        * User delete option
        * Input Param : User object
        */

        $scope.deleteUserClickEvent = function (user) {
            if (user.Id > 0) {
                var msg = "Do you want to delete ' " + user.FirstName + " '?";
                BootstrapDialog.confirm(msg, function (result) {
                    // 'OK' option
                    if (result) {
                        var dataUrl = configs.SERVICE_BASE_URL + 'Auth/DeleteUser';
                        var delObj = { Id: user.Id};
                        $http({
                            method: "POST",
                            url: dataUrl,
                            data: $.param(delObj),
                            headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
                        }).success(function (data, status, headers, config) {

                            if (data == 'true') {
                                getUsers();

                                BootstrapDialog.show({
                                    type: BootstrapDialog.TYPE_SUCCESS,
                                    title: 'Infromation',
                                    closable: false,
                                    message: "' " + user.FirstName + " '" + "Delete Successfully.",
                                    buttons: [{
                                        label: 'Ok',
                                        action: function (dialogItself) {
                                            dialogItself.close();
                                        }
                                    }]
                                });

                            } else {

                                BootstrapDialog.show({
                                    type: BootstrapDialog.TYPE_DANGER,
                                    title: 'Infromation',
                                    closable: false,
                                    message: "' " + user.FirstName + " '" + "Delete Fail, Please Try Again.",
                                    buttons: [{
                                        label: 'Ok',
                                        action: function (dialogItself) {
                                            dialogItself.close();
                                        }
                                    }]
                                });
                            }
                        }).
                          error(function (data, status, headers, config) {
                              console.log(data);
                              console.log(status);
                          });
                    }
                });
            }
        };


        /* Get role list from api call */
        function getUserRoles() {
            //$('#preloader').show();
            var dataUrl = configs.SERVICE_BASE_URL + 'Auth/GetUserRoles?branchId=' + 12;

            $http({
                method: "GET",
                url: dataUrl
            }).success(function (data, status, headers, config) {
                //$('#preloader').hide();

                $scope.dataSet = data;
                //$scope.parentTableParams.reload();
            }).
              error(function (data, status, headers, config) {
                  //$('#preloader').hide();
                  console.log(data);
                  console.log(status);
              });
        };
       // getUserRoles();

        /*
        * Role Save option
        * Input Param : Role object
        */
        $scope.saveUserRoleClickEvent = function () {
            hideValidations();
            if (isValidAlbumData()) {

                var roleObj = {
                    Id: $scope.role.Id,
                    Name: $scope.role.Name,
                    SortOrder: $scope.role.SortOrder,
                    CanDeleteOrUpdate: $scope.role.CanDeleteOrUpdate,
                    BranchId: eventBus.getBranchId(),
                    IsActive: $scope.user.IsActive,
                    EventDate: $filter('date')($scope.datepicker.EventDate, "yyyy-MM-dd")
                };

                var popupMsg = $scope.user.Id > 0 ? "Update" : "Save";

                //$('#preloader').show();
                var dataUrl = configs.SERVICE_BASE_URL + 'Auth/InsertOrUpdateUserRole';
                $http({
                    method: "POST",
                    url: dataUrl,
                    data: $.param(roleObj),
                    headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
                }).success(function (data, status, headers, config) {

                    if (data > 0) {
                        getUserRoles();
                        BootstrapDialog.show({
                            type: BootstrapDialog.TYPE_SUCCESS,
                            title: 'Infromation',
                            closable: false,
                            message: "Album " + popupMsg + "d Successfully.",
                            buttons: [{
                                label: 'Ok',
                                action: function (dialogItself) {
                                    dialogItself.close();
                                }
                            }]
                        });
                    } else {
                        $('#preloader').hide();
                        BootstrapDialog.show({
                            type: BootstrapDialog.TYPE_DANGER,
                            title: 'Infromation',
                            closable: false,
                            message: "Album " + popupMsg + " Fail, Please Try Again.",
                            buttons: [{
                                label: 'Ok',
                                action: function (dialogItself) {
                                    dialogItself.close();
                                }
                            }]
                        });
                    }
                }).
                error(function (data, status, headers, config) {
                    console.log(data);
                    console.log(status);
                });

            }
        };



        /*
        * Role delete option
        * Input Param : Role object
        */

        $scope.deleteRoleClickEvent = function (role) {
            if (role.Id > 0) {
                var msg = "Do you want to delete ' " + role.Name + " '?";
                BootstrapDialog.confirm(msg, function (result) {
                    // 'OK' option
                    if (result) {
                        var dataUrl = configs.SERVICE_BASE_URL + 'Auth/DeleteUserRole';
                        var delObj = { Id: role.Id };
                        $http({
                            method: "POST",
                            url: dataUrl,
                            data: $.param(delObj),
                            headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
                        }).success(function (data, status, headers, config) {

                            if (data == 'true') {
                                getUserRoles();

                                BootstrapDialog.show({
                                    type: BootstrapDialog.TYPE_SUCCESS,
                                    title: 'Infromation',
                                    closable: false,
                                    message: "' " + role.Name + " '" + "Delete Successfully.",
                                    buttons: [{
                                        label: 'Ok',
                                        action: function (dialogItself) {
                                            dialogItself.close();
                                        }
                                    }]
                                });

                            } else {

                                BootstrapDialog.show({
                                    type: BootstrapDialog.TYPE_DANGER,
                                    title: 'Infromation',
                                    closable: false,
                                    message: "' " + role.Name + " '" + "Delete Fail, Please Try Again.",
                                    buttons: [{
                                        label: 'Ok',
                                        action: function (dialogItself) {
                                            dialogItself.close();
                                        }
                                    }]
                                });
                            }
                        }).
                          error(function (data, status, headers, config) {
                              console.log(data);
                              console.log(status);
                          });
                    }
                });
            }
        };



        /* Get group list from api call */
        function getUserGroups() {
            //$('#preloader').show();
            var dataUrl = configs.SERVICE_BASE_URL + 'Auth/GetUserGroups?branchId=' + 12;

            $http({
                method: "GET",
                url: dataUrl
            }).success(function (data, status, headers, config) {
                //$('#preloader').hide();

                $scope.dataSet = data;
                //$scope.parentTableParams.reload();
            }).
              error(function (data, status, headers, config) {
                  //$('#preloader').hide();
                  console.log(data);
                  console.log(status);
              });
        };
       // getUserGroups();

        /*
        * Group Save option
        * Input Param : Group object
        */
        $scope.saveUserRoleClickEvent = function () {
            hideValidations();
            if (isValidAlbumData()) {

                var groupObj = {
                    Id: $scope.group.Id,
                    Name: $scope.group.Name,
                    Description: $scope.group.Description,
                    BranchId: eventBus.getBranchId(),
                    IsDelete: $scope.group.IsDelete
                };

                var popupMsg = $scope.user.Id > 0 ? "Update" : "Save";

                //$('#preloader').show();
                var dataUrl = configs.SERVICE_BASE_URL + 'Auth/InsertOrUpdateUserGroup';
                $http({
                    method: "POST",
                    url: dataUrl,
                    data: $.param(groupObj),
                    headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
                }).success(function (data, status, headers, config) {

                    if (data > 0) {
                        getUserGroups();
                        BootstrapDialog.show({
                            type: BootstrapDialog.TYPE_SUCCESS,
                            title: 'Infromation',
                            closable: false,
                            message: "Album " + popupMsg + "d Successfully.",
                            buttons: [{
                                label: 'Ok',
                                action: function (dialogItself) {
                                    dialogItself.close();
                                }
                            }]
                        });
                    } else {
                        $('#preloader').hide();
                        BootstrapDialog.show({
                            type: BootstrapDialog.TYPE_DANGER,
                            title: 'Infromation',
                            closable: false,
                            message: "Album " + popupMsg + " Fail, Please Try Again.",
                            buttons: [{
                                label: 'Ok',
                                action: function (dialogItself) {
                                    dialogItself.close();
                                }
                            }]
                        });
                    }
                }).
                error(function (data, status, headers, config) {
                    console.log(data);
                    console.log(status);
                });

            }
        };



        /*
        * Group delete option
        * Input Param : Group object
        */

        $scope.deleteGropupClickEvent = function (group) {
            if (group.Id > 0) {
                var msg = "Do you want to delete ' " + group.Name + " '?";
                BootstrapDialog.confirm(msg, function (result) {
                    // 'OK' option
                    if (result) {
                        var dataUrl = configs.SERVICE_BASE_URL + 'Auth/DeleteUserGroup';
                        var delObj = { Id: group.Id };
                        $http({
                            method: "POST",
                            url: dataUrl,
                            data: $.param(delObj),
                            headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
                        }).success(function (data, status, headers, config) {

                            if (data == 'true') {
                                getUserGroups();

                                BootstrapDialog.show({
                                    type: BootstrapDialog.TYPE_SUCCESS,
                                    title: 'Infromation',
                                    closable: false,
                                    message: "' " + group.Name + " '" + "Delete Successfully.",
                                    buttons: [{
                                        label: 'Ok',
                                        action: function (dialogItself) {
                                            dialogItself.close();
                                        }
                                    }]
                                });

                            } else {

                                BootstrapDialog.show({
                                    type: BootstrapDialog.TYPE_DANGER,
                                    title: 'Infromation',
                                    closable: false,
                                    message: "' " + group.Name + " '" + "Delete Fail, Please Try Again.",
                                    buttons: [{
                                        label: 'Ok',
                                        action: function (dialogItself) {
                                            dialogItself.close();
                                        }
                                    }]
                                });
                            }
                        }).
                          error(function (data, status, headers, config) {
                              console.log(data);
                              console.log(status);
                          });
                    }
                });
            }
        };


    };

    adminCtrl.$inject = ['$rootScope', '$scope', '$location', 'util', 'authorizationSvc', 'configs', '$http'];
    angular.module('d2cApp').controller('adminCtrl', adminCtrl);


}());