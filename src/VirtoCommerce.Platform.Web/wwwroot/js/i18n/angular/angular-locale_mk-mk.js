"use strict";angular.module("ngLocale",[],["$provide",function(e){function n(e){e+="";var n=e.indexOf(".");return n==-1?0:e.length-n-1}function r(e,r){var m=r;void 0===m&&(m=Math.min(n(e),3));var E=Math.pow(10,m),M=(e*E|0)%E;return{v:m,f:M}}var m={ZERO:"zero",ONE:"one",TWO:"two",FEW:"few",MANY:"many",OTHER:"other"};e.value("$locale",{DATETIME_FORMATS:{AMPMS:["претпладне","попладне"],DAY:["недела","понеделник","вторник","среда","четврток","петок","сабота"],ERANAMES:["пред нашата ера","од нашата ера"],ERAS:["пр.н.е.","н.е."],FIRSTDAYOFWEEK:0,MONTH:["јануари","февруари","март","април","мај","јуни","јули","август","септември","октомври","ноември","декември"],SHORTDAY:["нед.","пон.","вт.","сре.","чет.","пет.","саб."],SHORTMONTH:["јан.","фев.","мар.","апр.","мај","јун.","јул.","авг.","септ.","окт.","ноем.","дек."],WEEKENDRANGE:[5,6],fullDate:"EEEE, dd MMMM y",longDate:"dd MMMM y",medium:"dd.M.y HH:mm:ss",mediumDate:"dd.M.y",mediumTime:"HH:mm:ss",short:"dd.M.yy HH:mm",shortDate:"dd.M.yy",shortTime:"HH:mm"},NUMBER_FORMATS:{CURRENCY_SYM:"din",DECIMAL_SEP:",",GROUP_SEP:".",PATTERNS:[{gSize:3,lgSize:3,maxFrac:3,minFrac:0,minInt:1,negPre:"-",negSuf:"",posPre:"",posSuf:""},{gSize:3,lgSize:3,maxFrac:2,minFrac:2,minInt:1,negPre:"-¤ ",negSuf:"",posPre:"¤ ",posSuf:""}]},id:"mk-mk",pluralCat:function(e,n){var E=0|e,M=r(e,n);return 0==M.v&&E%10==1||M.f%10==1?m.ONE:m.OTHER}})}]);