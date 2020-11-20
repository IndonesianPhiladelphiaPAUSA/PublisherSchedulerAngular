"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
exports.__esModule = true;
exports.SharedService = void 0;
var core_1 = require("@angular/core");
var SharedService = /** @class */ (function () {
    function SharedService(http) {
        this.http = http;
        this.APIUrl = "https://localhost:44379/api";
        this.PhotoUrl = "https://localhost:44379/photos";
    }
    SharedService.prototype.getCapacityList = function () {
        return this.http.get(this.APIUrl + '/Capacities');
    };
    SharedService.prototype.addCapacity = function (val) {
        return this.http.post(this.APIUrl + '/Capacities', val);
    };
    SharedService.prototype.updateCapacity = function (val) {
        return this.http.put(this.APIUrl + '/Capacities', val);
    };
    SharedService.prototype.deleteCapacity = function (val) {
        return this.http["delete"](this.APIUrl + '/Capacities/' + val);
    };
    SharedService.prototype.getPersonList = function () {
        return this.http.get(this.APIUrl + '/Persons');
    };
    SharedService.prototype.addPerson = function (val) {
        return this.http.post(this.APIUrl + '/Persons', val);
    };
    SharedService.prototype.updatePerson = function (val) {
        return this.http.put(this.APIUrl + '/Persons', val);
    };
    SharedService.prototype.deletePerson = function (val) {
        return this.http["delete"](this.APIUrl + '/Persons/' + val);
    };
    SharedService.prototype.UploadPhoto = function (val) {
        return this.http.post(this.APIUrl + '/Persons/SaveFile', val);
    };
    SharedService.prototype.getAllCapacityNames = function () {
        return this.http.get(this.APIUrl + '/Persons/GetAllCapacityNames');
    };
    SharedService = __decorate([
        core_1.Injectable({
            providedIn: 'root'
        })
    ], SharedService);
    return SharedService;
}());
exports.SharedService = SharedService;
