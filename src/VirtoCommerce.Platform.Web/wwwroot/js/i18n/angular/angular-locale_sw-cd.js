"use strict";angular.module("ngLocale",[],["$provide",function(a){function i(a){a+="";var i=a.indexOf(".");return i==-1?0:a.length-i-1}function m(a,m){var e=m;void 0===e&&(e=Math.min(i(a),3));var n=Math.pow(10,e),t=(a*n|0)%n;return{v:e,f:t}}var e={ZERO:"zero",ONE:"one",TWO:"two",FEW:"few",MANY:"many",OTHER:"other"};a.value("$locale",{DATETIME_FORMATS:{AMPMS:["ya asubuyi","ya muchana"],DAY:["siku ya yenga","siku ya kwanza","siku ya pili","siku ya tatu","siku ya ine","siku ya tanu","siku ya sita"],ERANAMES:["Kabla ya Kristo","Baada ya Kristo"],ERAS:["BC","AD"],FIRSTDAYOFWEEK:0,MONTH:["mwezi ya kwanja","mwezi ya pili","mwezi ya tatu","mwezi ya ine","mwezi ya tanu","mwezi ya sita","mwezi ya saba","mwezi ya munane","mwezi ya tisa","mwezi ya kumi","mwezi ya kumi na moya","mwezi ya kumi ya mbili"],SHORTDAY:["yen","kwa","pil","tat","ine","tan","sit"],SHORTMONTH:["mkw","mpi","mtu","min","mtn","mst","msb","mun","mts","mku","mkm","mkb"],WEEKENDRANGE:[5,6],fullDate:"EEEE d MMMM y",longDate:"d MMMM y",medium:"d MMM y HH:mm:ss",mediumDate:"d MMM y",mediumTime:"HH:mm:ss",short:"d/M/y HH:mm",shortDate:"d/M/y",shortTime:"HH:mm"},NUMBER_FORMATS:{CURRENCY_SYM:"FrCD",DECIMAL_SEP:",",GROUP_SEP:".",PATTERNS:[{gSize:3,lgSize:3,maxFrac:3,minFrac:0,minInt:1,negPre:"-",negSuf:"",posPre:"",posSuf:""},{gSize:3,lgSize:3,maxFrac:2,minFrac:2,minInt:1,negPre:"-¤",negSuf:"",posPre:"¤",posSuf:""}]},id:"sw-cd",pluralCat:function(a,i){var n=0|a,t=m(a,i);return 1==n&&0==t.v?e.ONE:e.OTHER}})}]);