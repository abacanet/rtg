﻿/*
 Highcharts JS v5.0.3 (2016-11-18)

 (c) 2009-2016 Torstein Honsi

 License: www.highcharts.com/license
*/
(function (M, a) { "object" === typeof module && module.exports ? module.exports = M.document ? a(M) : a : M.Highcharts = a(M) })("undefined" !== typeof window ? window : this, function (M) {
    M = function () {
        var a = window, C = a.document, A = a.navigator && a.navigator.userAgent || "", D = C && C.createElementNS && !!C.createElementNS("http://www.w3.org/2000/svg", "svg").createSVGRect, F = /(edge|msie|trident)/i.test(A) && !window.opera, k = !D, d = /Firefox/.test(A), g = d && 4 > parseInt(A.split("Firefox/")[1], 10); return a.Highcharts ? a.Highcharts.error(16, !0) : {
            product: "Highcharts",
            version: "5.0.3", deg2rad: 2 * Math.PI / 360, doc: C, hasBidiBug: g, hasTouch: C && void 0 !== C.documentElement.ontouchstart, isMS: F, isWebKit: /AppleWebKit/.test(A), isFirefox: d, isTouchDevice: /(Mobile|Android|Windows Phone)/.test(A), SVG_NS: "http://www.w3.org/2000/svg", chartCount: 0, seriesTypes: {}, symbolSizes: {}, svg: D, vml: k, win: a, charts: [], marginNames: ["plotTop", "marginRight", "marginBottom", "plotLeft"], noop: function () { }
        }
    }(); (function (a) {
        var C = [], A = a.charts, D = a.doc, F = a.win; a.error = function (a, d) {
            a = "Highcharts error #" +
            a + ": www.highcharts.com/errors/" + a; if (d) throw Error(a); F.console && console.log(a)
        }; a.Fx = function (a, d, g) { this.options = d; this.elem = a; this.prop = g }; a.Fx.prototype = {
            dSetter: function () { var a = this.paths[0], d = this.paths[1], g = [], u = this.now, l = a.length, t; if (1 === u) g = this.toD; else if (l === d.length && 1 > u) for (; l--;) t = parseFloat(a[l]), g[l] = isNaN(t) ? a[l] : u * parseFloat(d[l] - t) + t; else g = d; this.elem.attr("d", g) }, update: function () {
                var a = this.elem, d = this.prop, g = this.now, u = this.options.step; if (this[d + "Setter"]) this[d + "Setter"]();
                else a.attr ? a.element && a.attr(d, g) : a.style[d] = g + this.unit; u && u.call(a, g, this)
            }, run: function (a, d, g) { var k = this, l = function (a) { return l.stopped ? !1 : k.step(a) }, t; this.startTime = +new Date; this.start = a; this.end = d; this.unit = g; this.now = this.start; this.pos = 0; l.elem = this.elem; l() && 1 === C.push(l) && (l.timerId = setInterval(function () { for (t = 0; t < C.length; t++) C[t]() || C.splice(t--, 1); C.length || clearInterval(l.timerId) }, 13)) }, step: function (a) {
                var d = +new Date, g, k = this.options; g = this.elem; var l = k.complete, t = k.duration,
                n = k.curAnim, f; if (g.attr && !g.element) g = !1; else if (a || d >= t + this.startTime) { this.now = this.end; this.pos = 1; this.update(); a = n[this.prop] = !0; for (f in n) !0 !== n[f] && (a = !1); a && l && l.call(g); g = !1 } else this.pos = k.easing((d - this.startTime) / t), this.now = this.start + (this.end - this.start) * this.pos, this.update(), g = !0; return g
            }, initPath: function (k, d, g) {
                function u(a) { for (m = a.length; m--;) "M" !== a[m] && "L" !== a[m] || a.splice(m + 1, 0, a[m + 1], a[m + 2], a[m + 1], a[m + 2]) } function l(a, b) {
                    for (; a.length < c;) {
                        a[0] = b[c - a.length]; var e = a.slice(0,
                        H);[].splice.apply(a, [0, 0].concat(e)); r && (e = a.slice(a.length - H), [].splice.apply(a, [a.length, 0].concat(e)), m--)
                    } a[0] = "M"
                } function t(a, b) { for (var q = (c - a.length) / H; 0 < q && q--;) e = a.slice().splice(a.length / I - H, H * I), e[0] = b[c - H - q * H], v && (e[H - 6] = e[H - 2], e[H - 5] = e[H - 1]), [].splice.apply(a, [a.length / I, 0].concat(e)), r && q-- } d = d || ""; var n, f = k.startX, h = k.endX, v = -1 < d.indexOf("C"), H = v ? 7 : 3, c, e, m; d = d.split(" "); g = g.slice(); var r = k.isArea, I = r ? 2 : 1, b; v && (u(d), u(g)); if (f && h) {
                    for (m = 0; m < f.length; m++) if (f[m] === h[0]) { n = m; break } else if (f[0] ===
                    h[h.length - f.length + m]) { n = m; b = !0; break } void 0 === n && (d = [])
                } d.length && a.isNumber(n) && (c = g.length + n * I * H, b ? (l(d, g), t(g, d)) : (l(g, d), t(d, g))); return [d, g]
            }
        }; a.extend = function (a, d) { var g; a || (a = {}); for (g in d) a[g] = d[g]; return a }; a.merge = function () {
            var k, d = arguments, g, u = {}, l = function (t, d) { var f, h; "object" !== typeof t && (t = {}); for (h in d) d.hasOwnProperty(h) && (f = d[h], a.isObject(f, !0) && "renderTo" !== h && "number" !== typeof f.nodeType ? t[h] = l(t[h] || {}, f) : t[h] = d[h]); return t }; !0 === d[0] && (u = d[1], d = Array.prototype.slice.call(d,
            2)); g = d.length; for (k = 0; k < g; k++) u = l(u, d[k]); return u
        }; a.pInt = function (a, d) { return parseInt(a, d || 10) }; a.isString = function (a) { return "string" === typeof a }; a.isArray = function (a) { a = Object.prototype.toString.call(a); return "[object Array]" === a || "[object Array Iterator]" === a }; a.isObject = function (k, d) { return k && "object" === typeof k && (!d || !a.isArray(k)) }; a.isNumber = function (a) { return "number" === typeof a && !isNaN(a) }; a.erase = function (a, d) { for (var g = a.length; g--;) if (a[g] === d) { a.splice(g, 1); break } }; a.defined = function (a) {
            return void 0 !==
            a && null !== a
        }; a.attr = function (k, d, g) { var u, l; if (a.isString(d)) a.defined(g) ? k.setAttribute(d, g) : k && k.getAttribute && (l = k.getAttribute(d)); else if (a.defined(d) && a.isObject(d)) for (u in d) k.setAttribute(u, d[u]); return l }; a.splat = function (k) { return a.isArray(k) ? k : [k] }; a.syncTimeout = function (a, d, g) { if (d) return setTimeout(a, d, g); a.call(0, g) }; a.pick = function () { var a = arguments, d, g, u = a.length; for (d = 0; d < u; d++) if (g = a[d], void 0 !== g && null !== g) return g }; a.css = function (k, d) {
            a.isMS && !a.svg && d && void 0 !== d.opacity && (d.filter =
            "alpha(opacity\x3d" + 100 * d.opacity + ")"); a.extend(k.style, d)
        }; a.createElement = function (k, d, g, u, l) { k = D.createElement(k); var t = a.css; d && a.extend(k, d); l && t(k, { padding: 0, border: "none", margin: 0 }); g && t(k, g); u && u.appendChild(k); return k }; a.extendClass = function (k, d) { var g = function () { }; g.prototype = new k; a.extend(g.prototype, d); return g }; a.pad = function (a, d, g) { return Array((d || 2) + 1 - String(a).length).join(g || 0) + a }; a.relativeLength = function (a, d) { return /%$/.test(a) ? d * parseFloat(a) / 100 : parseFloat(a) }; a.wrap = function (a,
        d, g) { var k = a[d]; a[d] = function () { var a = Array.prototype.slice.call(arguments), d = arguments, n = this; n.proceed = function () { k.apply(n, arguments.length ? arguments : d) }; a.unshift(k); a = g.apply(this, a); n.proceed = null; return a } }; a.getTZOffset = function (k) { var d = a.Date; return 6E4 * (d.hcGetTimezoneOffset && d.hcGetTimezoneOffset(k) || d.hcTimezoneOffset || 0) }; a.dateFormat = function (k, d, g) {
            if (!a.defined(d) || isNaN(d)) return a.defaultOptions.lang.invalidDate || ""; k = a.pick(k, "%Y-%m-%d %H:%M:%S"); var u = a.Date, l = new u(d - a.getTZOffset(d)),
            t, n = l[u.hcGetHours](), f = l[u.hcGetDay](), h = l[u.hcGetDate](), v = l[u.hcGetMonth](), H = l[u.hcGetFullYear](), c = a.defaultOptions.lang, e = c.weekdays, m = c.shortWeekdays, r = a.pad, u = a.extend({ a: m ? m[f] : e[f].substr(0, 3), A: e[f], d: r(h), e: r(h, 2, " "), w: f, b: c.shortMonths[v], B: c.months[v], m: r(v + 1), y: H.toString().substr(2, 2), Y: H, H: r(n), k: n, I: r(n % 12 || 12), l: n % 12 || 12, M: r(l[u.hcGetMinutes]()), p: 12 > n ? "AM" : "PM", P: 12 > n ? "am" : "pm", S: r(l.getSeconds()), L: r(Math.round(d % 1E3), 3) }, a.dateFormats); for (t in u) for (; -1 !== k.indexOf("%" + t) ;) k =
            k.replace("%" + t, "function" === typeof u[t] ? u[t](d) : u[t]); return g ? k.substr(0, 1).toUpperCase() + k.substr(1) : k
        }; a.formatSingle = function (k, d) { var g = /\.([0-9])/, u = a.defaultOptions.lang; /f$/.test(k) ? (g = (g = k.match(g)) ? g[1] : -1, null !== d && (d = a.numberFormat(d, g, u.decimalPoint, -1 < k.indexOf(",") ? u.thousandsSep : ""))) : d = a.dateFormat(k, d); return d }; a.format = function (k, d) {
            for (var g = "{", u = !1, l, t, n, f, h = [], v; k;) {
                g = k.indexOf(g); if (-1 === g) break; l = k.slice(0, g); if (u) {
                    l = l.split(":"); t = l.shift().split("."); f = t.length; v = d; for (n =
                    0; n < f; n++) v = v[t[n]]; l.length && (v = a.formatSingle(l.join(":"), v)); h.push(v)
                } else h.push(l); k = k.slice(g + 1); g = (u = !u) ? "}" : "{"
            } h.push(k); return h.join("")
        }; a.getMagnitude = function (a) { return Math.pow(10, Math.floor(Math.log(a) / Math.LN10)) }; a.normalizeTickInterval = function (k, d, g, u, l) {
            var t, n = k; g = a.pick(g, 1); t = k / g; d || (d = l ? [1, 1.2, 1.5, 2, 2.5, 3, 4, 5, 6, 8, 10] : [1, 2, 2.5, 5, 10], !1 === u && (1 === g ? d = a.grep(d, function (a) { return 0 === a % 1 }) : .1 >= g && (d = [1 / g]))); for (u = 0; u < d.length && !(n = d[u], l && n * g >= k || !l && t <= (d[u] + (d[u + 1] || d[u])) /
            2) ; u++); return n * g
        }; a.stableSort = function (a, d) { var g = a.length, k, l; for (l = 0; l < g; l++) a[l].safeI = l; a.sort(function (a, l) { k = d(a, l); return 0 === k ? a.safeI - l.safeI : k }); for (l = 0; l < g; l++) delete a[l].safeI }; a.arrayMin = function (a) { for (var d = a.length, g = a[0]; d--;) a[d] < g && (g = a[d]); return g }; a.arrayMax = function (a) { for (var d = a.length, g = a[0]; d--;) a[d] > g && (g = a[d]); return g }; a.destroyObjectProperties = function (a, d) { for (var g in a) a[g] && a[g] !== d && a[g].destroy && a[g].destroy(), delete a[g] }; a.discardElement = function (k) {
            var d =
            a.garbageBin; d || (d = a.createElement("div")); k && d.appendChild(k); d.innerHTML = ""
        }; a.correctFloat = function (a, d) { return parseFloat(a.toPrecision(d || 14)) }; a.setAnimation = function (k, d) { d.renderer.globalAnimation = a.pick(k, d.options.chart.animation, !0) }; a.animObject = function (k) { return a.isObject(k) ? a.merge(k) : { duration: k ? 500 : 0 } }; a.timeUnits = { millisecond: 1, second: 1E3, minute: 6E4, hour: 36E5, day: 864E5, week: 6048E5, month: 24192E5, year: 314496E5 }; a.numberFormat = function (k, d, g, u) {
            k = +k || 0; d = +d; var l = a.defaultOptions.lang,
            t = (k.toString().split(".")[1] || "").length, n, f, h = Math.abs(k); -1 === d ? d = Math.min(t, 20) : a.isNumber(d) || (d = 2); n = String(a.pInt(h.toFixed(d))); f = 3 < n.length ? n.length % 3 : 0; g = a.pick(g, l.decimalPoint); u = a.pick(u, l.thousandsSep); k = (0 > k ? "-" : "") + (f ? n.substr(0, f) + u : ""); k += n.substr(f).replace(/(\d{3})(?=\d)/g, "$1" + u); d && (u = Math.abs(h - n + Math.pow(10, -Math.max(d, t) - 1)), k += g + u.toFixed(d).slice(2)); return k
        }; Math.easeInOutSine = function (a) { return -.5 * (Math.cos(Math.PI * a) - 1) }; a.getStyle = function (k, d) {
            return "width" === d ? Math.min(k.offsetWidth,
            k.scrollWidth) - a.getStyle(k, "padding-left") - a.getStyle(k, "padding-right") : "height" === d ? Math.min(k.offsetHeight, k.scrollHeight) - a.getStyle(k, "padding-top") - a.getStyle(k, "padding-bottom") : (k = F.getComputedStyle(k, void 0)) && a.pInt(k.getPropertyValue(d))
        }; a.inArray = function (a, d) { return d.indexOf ? d.indexOf(a) : [].indexOf.call(d, a) }; a.grep = function (a, d) { return [].filter.call(a, d) }; a.map = function (a, d) { for (var g = [], k = 0, l = a.length; k < l; k++) g[k] = d.call(a[k], a[k], k, a); return g }; a.offset = function (a) {
            var d = D.documentElement;
            a = a.getBoundingClientRect(); return { top: a.top + (F.pageYOffset || d.scrollTop) - (d.clientTop || 0), left: a.left + (F.pageXOffset || d.scrollLeft) - (d.clientLeft || 0) }
        }; a.stop = function (a) { for (var d = C.length; d--;) C[d].elem === a && (C[d].stopped = !0) }; a.each = function (a, d, g) { return Array.prototype.forEach.call(a, d, g) }; a.addEvent = function (k, d, g) {
            function u(a) { a.target = a.srcElement || F; g.call(k, a) } var l = k.hcEvents = k.hcEvents || {}; k.addEventListener ? k.addEventListener(d, g, !1) : k.attachEvent && (k.hcEventsIE || (k.hcEventsIE = {}),
            k.hcEventsIE[g.toString()] = u, k.attachEvent("on" + d, u)); l[d] || (l[d] = []); l[d].push(g); return function () { a.removeEvent(k, d, g) }
        }; a.removeEvent = function (k, d, g) {
            function u(a, f) { k.removeEventListener ? k.removeEventListener(a, f, !1) : k.attachEvent && (f = k.hcEventsIE[f.toString()], k.detachEvent("on" + a, f)) } function l() { var a, f; if (k.nodeName) for (f in d ? (a = {}, a[d] = !0) : a = n, a) if (n[f]) for (a = n[f].length; a--;) u(f, n[f][a]) } var t, n = k.hcEvents, f; n && (d ? (t = n[d] || [], g ? (f = a.inArray(g, t), -1 < f && (t.splice(f, 1), n[d] = t), u(d, g)) : (l(),
            n[d] = [])) : (l(), k.hcEvents = {}))
        }; a.fireEvent = function (k, d, g, u) { var l; l = k.hcEvents; var t, n; g = g || {}; if (D.createEvent && (k.dispatchEvent || k.fireEvent)) l = D.createEvent("Events"), l.initEvent(d, !0, !0), a.extend(l, g), k.dispatchEvent ? k.dispatchEvent(l) : k.fireEvent(d, l); else if (l) for (l = l[d] || [], t = l.length, g.target || a.extend(g, { preventDefault: function () { g.defaultPrevented = !0 }, target: k, type: d }), d = 0; d < t; d++) (n = l[d]) && !1 === n.call(k, g) && g.preventDefault(); u && !g.defaultPrevented && u(g) }; a.animate = function (k, d, g) {
            var u,
            l = "", t, n, f; a.isObject(g) || (u = arguments, g = { duration: u[2], easing: u[3], complete: u[4] }); a.isNumber(g.duration) || (g.duration = 400); g.easing = "function" === typeof g.easing ? g.easing : Math[g.easing] || Math.easeInOutSine; g.curAnim = a.merge(d); for (f in d) n = new a.Fx(k, g, f), t = null, "d" === f ? (n.paths = n.initPath(k, k.d, d.d), n.toD = d.d, u = 0, t = 1) : k.attr ? u = k.attr(f) : (u = parseFloat(a.getStyle(k, f)) || 0, "opacity" !== f && (l = "px")), t || (t = d[f]), t.match && t.match("px") && (t = t.replace(/px/g, "")), n.run(u, t, l)
        }; a.seriesType = function (k, d, g,
        u, l) { var t = a.getOptions(), n = a.seriesTypes; t.plotOptions[k] = a.merge(t.plotOptions[d], g); n[k] = a.extendClass(n[d] || function () { }, u); n[k].prototype.type = k; l && (n[k].prototype.pointClass = a.extendClass(a.Point, l)); return n[k] }; a.uniqueKey = function () { var a = Math.random().toString(36).substring(2, 9), d = 0; return function () { return "highcharts-" + a + "-" + d++ } }(); F.jQuery && (F.jQuery.fn.highcharts = function () {
            var k = [].slice.call(arguments); if (this[0]) return k[0] ? (new (a[a.isString(k[0]) ? k.shift() : "Chart"])(this[0], k[0],
            k[1]), this) : A[a.attr(this[0], "data-highcharts-chart")]
        }); D && !D.defaultView && (a.getStyle = function (k, d) { var g = { width: "clientWidth", height: "clientHeight" }[d]; if (k.style[d]) return a.pInt(k.style[d]); "opacity" === d && (d = "filter"); if (g) return k.style.zoom = 1, Math.max(k[g] - 2 * a.getStyle(k, "padding"), 0); k = k.currentStyle[d.replace(/\-(\w)/g, function (a, d) { return d.toUpperCase() })]; "filter" === d && (k = k.replace(/alpha\(opacity=([0-9]+)\)/, function (a, d) { return d / 100 })); return "" === k ? 1 : a.pInt(k) }); Array.prototype.forEach ||
        (a.each = function (a, d, g) { for (var k = 0, l = a.length; k < l; k++) if (!1 === d.call(g, a[k], k, a)) return k }); Array.prototype.indexOf || (a.inArray = function (a, d) { var g, k = 0; if (d) for (g = d.length; k < g; k++) if (d[k] === a) return k; return -1 }); Array.prototype.filter || (a.grep = function (a, d) { for (var g = [], k = 0, l = a.length; k < l; k++) d(a[k], k) && g.push(a[k]); return g })
    })(M); (function (a) {
        var C = a.each, A = a.isNumber, D = a.map, F = a.merge, k = a.pInt; a.Color = function (d) { if (!(this instanceof a.Color)) return new a.Color(d); this.init(d) }; a.Color.prototype =
        {
            parsers: [{ regex: /rgba\(\s*([0-9]{1,3})\s*,\s*([0-9]{1,3})\s*,\s*([0-9]{1,3})\s*,\s*([0-9]?(?:\.[0-9]+)?)\s*\)/, parse: function (a) { return [k(a[1]), k(a[2]), k(a[3]), parseFloat(a[4], 10)] } }, { regex: /#([a-fA-F0-9]{2})([a-fA-F0-9]{2})([a-fA-F0-9]{2})/, parse: function (a) { return [k(a[1], 16), k(a[2], 16), k(a[3], 16), 1] } }, { regex: /rgb\(\s*([0-9]{1,3})\s*,\s*([0-9]{1,3})\s*,\s*([0-9]{1,3})\s*\)/, parse: function (a) { return [k(a[1]), k(a[2]), k(a[3]), 1] } }], names: { white: "#ffffff", black: "#000000" }, init: function (d) {
                var g, k, l,
                t; if ((this.input = d = this.names[d] || d) && d.stops) this.stops = D(d.stops, function (l) { return new a.Color(l[1]) }); else for (l = this.parsers.length; l-- && !k;) t = this.parsers[l], (g = t.regex.exec(d)) && (k = t.parse(g)); this.rgba = k || []
            }, get: function (a) { var d = this.input, k = this.rgba, l; this.stops ? (l = F(d), l.stops = [].concat(l.stops), C(this.stops, function (d, g) { l.stops[g] = [l.stops[g][0], d.get(a)] })) : l = k && A(k[0]) ? "rgb" === a || !a && 1 === k[3] ? "rgb(" + k[0] + "," + k[1] + "," + k[2] + ")" : "a" === a ? k[3] : "rgba(" + k.join(",") + ")" : d; return l }, brighten: function (a) {
                var d,
                u = this.rgba; if (this.stops) C(this.stops, function (l) { l.brighten(a) }); else if (A(a) && 0 !== a) for (d = 0; 3 > d; d++) u[d] += k(255 * a), 0 > u[d] && (u[d] = 0), 255 < u[d] && (u[d] = 255); return this
            }, setOpacity: function (a) { this.rgba[3] = a; return this }
        }; a.color = function (d) { return new a.Color(d) }
    })(M); (function (a) {
        var C, A, D = a.addEvent, F = a.animate, k = a.attr, d = a.charts, g = a.color, u = a.css, l = a.createElement, t = a.defined, n = a.deg2rad, f = a.destroyObjectProperties, h = a.doc, v = a.each, H = a.extend, c = a.erase, e = a.grep, m = a.hasTouch, r = a.isArray, I = a.isFirefox,
        b = a.isMS, q = a.isObject, x = a.isString, L = a.isWebKit, E = a.merge, J = a.noop, w = a.pick, K = a.pInt, G = a.removeEvent, N = a.stop, p = a.svg, y = a.SVG_NS, P = a.symbolSizes, O = a.win; C = a.SVGElement = function () { return this }; C.prototype = {
            opacity: 1, SVG_NS: y, textProps: "direction fontSize fontWeight fontFamily fontStyle color lineHeight width textDecoration textOverflow textOutline".split(" "), init: function (a, b) { this.element = "span" === b ? l(b) : h.createElementNS(this.SVG_NS, b); this.renderer = a }, animate: function (a, b, p) {
                b = w(b, this.renderer.globalAnimation,
                !0); N(this); b ? (p && (b.complete = p), F(this, a, b)) : this.attr(a, null, p); return this
            }, colorGradient: function (B, b, p) {
                var z = this.renderer, e, y, c, q, f, x, m, S, h, w, l, d = [], G; B.linearGradient ? y = "linearGradient" : B.radialGradient && (y = "radialGradient"); if (y) {
                    c = B[y]; f = z.gradients; m = B.stops; w = p.radialReference; r(c) && (B[y] = c = { x1: c[0], y1: c[1], x2: c[2], y2: c[3], gradientUnits: "userSpaceOnUse" }); "radialGradient" === y && w && !t(c.gradientUnits) && (q = c, c = E(c, z.getRadialAttr(w, q), { gradientUnits: "userSpaceOnUse" })); for (l in c) "id" !==
                    l && d.push(l, c[l]); for (l in m) d.push(m[l]); d = d.join(","); f[d] ? w = f[d].attr("id") : (c.id = w = a.uniqueKey(), f[d] = x = z.createElement(y).attr(c).add(z.defs), x.radAttr = q, x.stops = [], v(m, function (B) { 0 === B[1].indexOf("rgba") ? (e = a.color(B[1]), S = e.get("rgb"), h = e.get("a")) : (S = B[1], h = 1); B = z.createElement("stop").attr({ offset: B[0], "stop-color": S, "stop-opacity": h }).add(x); x.stops.push(B) })); G = "url(" + z.url + "#" + w + ")"; p.setAttribute(b, G); p.gradient = d; B.toString = function () { return G }
                }
            }, applyTextOutline: function (a) {
                var B =
                this.element, b, p, e; -1 !== a.indexOf("contrast") && (a = a.replace(/contrast/g, this.renderer.getContrast(B.style.fill))); this.fakeTS = !0; this.ySetter = this.xSetter; b = [].slice.call(B.getElementsByTagName("tspan")); a = a.split(" "); p = a[a.length - 1]; (e = a[0]) && "none" !== e && (e = e.replace(/(^[\d\.]+)(.*?)$/g, function (a, B, b) { return 2 * B + b }), v(b, function (a) { "highcharts-text-outline" === a.getAttribute("class") && c(b, B.removeChild(a)) }), this.realBox = B.getBBox(), v(b, function (a, b) {
                    0 === b && (a.setAttribute("x", B.getAttribute("x")),
                    b = B.getAttribute("y"), a.setAttribute("y", b || 0), null === b && B.setAttribute("y", 0)); a = a.cloneNode(1); k(a, { "class": "highcharts-text-outline", fill: p, stroke: p, "stroke-width": e, "stroke-linejoin": "round" }); B.insertBefore(a, B.firstChild)
                }))
            }, attr: function (a, b, p) {
                var B, z = this.element, e, y = this, c; "string" === typeof a && void 0 !== b && (B = a, a = {}, a[B] = b); if ("string" === typeof a) y = (this[a + "Getter"] || this._defaultGetter).call(this, a, z); else {
                    for (B in a) b = a[B], c = !1, this.symbolName && /^(x|y|width|height|r|start|end|innerR|anchorX|anchorY)/.test(B) &&
                    (e || (this.symbolAttr(a), e = !0), c = !0), !this.rotation || "x" !== B && "y" !== B || (this.doTransform = !0), c || (c = this[B + "Setter"] || this._defaultSetter, c.call(this, b, B, z), this.shadows && /^(width|height|visibility|x|y|d|transform|cx|cy|r)$/.test(B) && this.updateShadows(B, b, c)); this.doTransform && (this.updateTransform(), this.doTransform = !1)
                } p && p(); return y
            }, updateShadows: function (a, b, p) { for (var B = this.shadows, z = B.length; z--;) p.call(B[z], "height" === a ? Math.max(b - (B[z].cutHeight || 0), 0) : "d" === a ? this.d : b, a, B[z]) }, addClass: function (a,
            b) { var B = this.attr("class") || ""; -1 === B.indexOf(a) && (b || (a = (B + (B ? " " : "") + a).replace("  ", " ")), this.attr("class", a)); return this }, hasClass: function (a) { return -1 !== k(this.element, "class").indexOf(a) }, removeClass: function (a) { k(this.element, "class", (k(this.element, "class") || "").replace(a, "")); return this }, symbolAttr: function (a) {
                var B = this; v("x y r start end width height innerR anchorX anchorY".split(" "), function (b) { B[b] = w(a[b], B[b]) }); B.attr({
                    d: B.renderer.symbols[B.symbolName](B.x, B.y, B.width, B.height,
                    B)
                })
            }, clip: function (a) { return this.attr("clip-path", a ? "url(" + this.renderer.url + "#" + a.id + ")" : "none") }, crisp: function (a, b) { var B, z = {}, p; b = b || a.strokeWidth || 0; p = Math.round(b) % 2 / 2; a.x = Math.floor(a.x || this.x || 0) + p; a.y = Math.floor(a.y || this.y || 0) + p; a.width = Math.floor((a.width || this.width || 0) - 2 * p); a.height = Math.floor((a.height || this.height || 0) - 2 * p); t(a.strokeWidth) && (a.strokeWidth = b); for (B in a) this[B] !== a[B] && (this[B] = z[B] = a[B]); return z }, css: function (a) {
                var B = this.styles, e = {}, y = this.element, c, q, f = ""; c =
                !B; a && a.color && (a.fill = a.color); if (B) for (q in a) a[q] !== B[q] && (e[q] = a[q], c = !0); if (c) { c = this.textWidth = a && a.width && "text" === y.nodeName.toLowerCase() && K(a.width) || this.textWidth; B && (a = H(B, e)); this.styles = a; c && !p && this.renderer.forExport && delete a.width; if (b && !p) u(this.element, a); else { B = function (a, b) { return "-" + b.toLowerCase() }; for (q in a) f += q.replace(/([A-Z])/g, B) + ":" + a[q] + ";"; k(y, "style", f) } this.added && (c && this.renderer.buildText(this), a && a.textOutline && this.applyTextOutline(a.textOutline)) } return this
            },
            strokeWidth: function () { return this["stroke-width"] || 0 }, on: function (a, b) { var B = this, p = B.element; m && "click" === a ? (p.ontouchstart = function (a) { B.touchEventFired = Date.now(); a.preventDefault(); b.call(p, a) }, p.onclick = function (a) { (-1 === O.navigator.userAgent.indexOf("Android") || 1100 < Date.now() - (B.touchEventFired || 0)) && b.call(p, a) }) : p["on" + a] = b; return this }, setRadialReference: function (a) {
                var b = this.renderer.gradients[this.element.gradient]; this.element.radialReference = a; b && b.radAttr && b.animate(this.renderer.getRadialAttr(a,
                b.radAttr)); return this
            }, translate: function (a, b) { return this.attr({ translateX: a, translateY: b }) }, invert: function (a) { this.inverted = a; this.updateTransform(); return this }, updateTransform: function () {
                var a = this.translateX || 0, b = this.translateY || 0, p = this.scaleX, e = this.scaleY, y = this.inverted, c = this.rotation, q = this.element; y && (a += this.attr("width"), b += this.attr("height")); a = ["translate(" + a + "," + b + ")"]; y ? a.push("rotate(90) scale(-1,1)") : c && a.push("rotate(" + c + " " + (q.getAttribute("x") || 0) + " " + (q.getAttribute("y") ||
                0) + ")"); (t(p) || t(e)) && a.push("scale(" + w(p, 1) + " " + w(e, 1) + ")"); a.length && q.setAttribute("transform", a.join(" "))
            }, toFront: function () { var a = this.element; a.parentNode.appendChild(a); return this }, align: function (a, b, p) {
                var B, z, e, y, q = {}; z = this.renderer; e = z.alignedObjects; var f, m; if (a) { if (this.alignOptions = a, this.alignByTranslate = b, !p || x(p)) this.alignTo = B = p || "renderer", c(e, this), e.push(this), p = null } else a = this.alignOptions, b = this.alignByTranslate, B = this.alignTo; p = w(p, z[B], z); B = a.align; z = a.verticalAlign; e =
                (p.x || 0) + (a.x || 0); y = (p.y || 0) + (a.y || 0); "right" === B ? f = 1 : "center" === B && (f = 2); f && (e += (p.width - (a.width || 0)) / f); q[b ? "translateX" : "x"] = Math.round(e); "bottom" === z ? m = 1 : "middle" === z && (m = 2); m && (y += (p.height - (a.height || 0)) / m); q[b ? "translateY" : "y"] = Math.round(y); this[this.placed ? "animate" : "attr"](q); this.placed = !0; this.alignAttr = q; return this
            }, getBBox: function (a, p) {
                var B, z = this.renderer, e, y = this.element, c = this.styles, q, f = this.textStr, m, x = z.cache, h = z.cacheKeys, r; p = w(p, this.rotation); e = p * n; q = c && c.fontSize; void 0 !==
                f && (r = f.toString(), -1 === r.indexOf("\x3c") && (r = r.replace(/[0-9]/g, "0")), r += ["", p || 0, q, y.style.width, y.style["text-overflow"]].join()); r && !a && (B = x[r]); if (!B) {
                    if (y.namespaceURI === this.SVG_NS || z.forExport) { try { (m = this.fakeTS && function (a) { v(y.querySelectorAll(".highcharts-text-outline"), function (b) { b.style.display = a }) }) && m("none"), B = y.getBBox ? H({}, y.getBBox()) : { width: y.offsetWidth, height: y.offsetHeight }, m && m("") } catch (U) { } if (!B || 0 > B.width) B = { width: 0, height: 0 } } else B = this.htmlGetBBox(); z.isSVG && (a = B.width,
                    z = B.height, b && c && "11px" === c.fontSize && "16.9" === z.toPrecision(3) && (B.height = z = 14), p && (B.width = Math.abs(z * Math.sin(e)) + Math.abs(a * Math.cos(e)), B.height = Math.abs(z * Math.cos(e)) + Math.abs(a * Math.sin(e)))); if (r && 0 < B.height) { for (; 250 < h.length;) delete x[h.shift()]; x[r] || h.push(r); x[r] = B }
                } return B
            }, show: function (a) { return this.attr({ visibility: a ? "inherit" : "visible" }) }, hide: function () { return this.attr({ visibility: "hidden" }) }, fadeOut: function (a) { var b = this; b.animate({ opacity: 0 }, { duration: a || 150, complete: function () { b.attr({ y: -9999 }) } }) },
            add: function (a) { var b = this.renderer, B = this.element, p; a && (this.parentGroup = a); this.parentInverted = a && a.inverted; void 0 !== this.textStr && b.buildText(this); this.added = !0; if (!a || a.handleZ || this.zIndex) p = this.zIndexSetter(); p || (a ? a.element : b.box).appendChild(B); if (this.onAdd) this.onAdd(); return this }, safeRemoveChild: function (a) { var b = a.parentNode; b && b.removeChild(a) }, destroy: function () {
                var a = this.element || {}, b = this.renderer.isSVG && "SPAN" === a.nodeName && this.parentGroup, p, e; a.onclick = a.onmouseout = a.onmouseover =
                a.onmousemove = a.point = null; N(this); this.clipPath && (this.clipPath = this.clipPath.destroy()); if (this.stops) { for (e = 0; e < this.stops.length; e++) this.stops[e] = this.stops[e].destroy(); this.stops = null } this.safeRemoveChild(a); for (this.destroyShadows() ; b && b.div && 0 === b.div.childNodes.length;) a = b.parentGroup, this.safeRemoveChild(b.div), delete b.div, b = a; this.alignTo && c(this.renderer.alignedObjects, this); for (p in this) delete this[p]; return null
            }, shadow: function (a, b, p) {
                var B = [], z, e, y = this.element, c, q, f, m; if (!a) this.destroyShadows();
                else if (!this.shadows) { q = w(a.width, 3); f = (a.opacity || .15) / q; m = this.parentInverted ? "(-1,-1)" : "(" + w(a.offsetX, 1) + ", " + w(a.offsetY, 1) + ")"; for (z = 1; z <= q; z++) e = y.cloneNode(0), c = 2 * q + 1 - 2 * z, k(e, { isShadow: "true", stroke: a.color || "#000000", "stroke-opacity": f * z, "stroke-width": c, transform: "translate" + m, fill: "none" }), p && (k(e, "height", Math.max(k(e, "height") - c, 0)), e.cutHeight = c), b ? b.element.appendChild(e) : y.parentNode.insertBefore(e, y), B.push(e); this.shadows = B } return this
            }, destroyShadows: function () {
                v(this.shadows ||
                [], function (a) { this.safeRemoveChild(a) }, this); this.shadows = void 0
            }, xGetter: function (a) { "circle" === this.element.nodeName && ("x" === a ? a = "cx" : "y" === a && (a = "cy")); return this._defaultGetter(a) }, _defaultGetter: function (a) { a = w(this[a], this.element ? this.element.getAttribute(a) : null, 0); /^[\-0-9\.]+$/.test(a) && (a = parseFloat(a)); return a }, dSetter: function (a, b, p) { a && a.join && (a = a.join(" ")); /(NaN| {2}|^$)/.test(a) && (a = "M 0 0"); p.setAttribute(b, a); this[b] = a }, dashstyleSetter: function (a) {
                var b, p = this["stroke-width"];
                "inherit" === p && (p = 1); if (a = a && a.toLowerCase()) { a = a.replace("shortdashdotdot", "3,1,1,1,1,1,").replace("shortdashdot", "3,1,1,1").replace("shortdot", "1,1,").replace("shortdash", "3,1,").replace("longdash", "8,3,").replace(/dot/g, "1,3,").replace("dash", "4,3,").replace(/,$/, "").split(","); for (b = a.length; b--;) a[b] = K(a[b]) * p; a = a.join(",").replace(/NaN/g, "none"); this.element.setAttribute("stroke-dasharray", a) }
            }, alignSetter: function (a) { this.element.setAttribute("text-anchor", { left: "start", center: "middle", right: "end" }[a]) },
            opacitySetter: function (a, b, p) { this[b] = a; p.setAttribute(b, a) }, titleSetter: function (a) { var b = this.element.getElementsByTagName("title")[0]; b || (b = h.createElementNS(this.SVG_NS, "title"), this.element.appendChild(b)); b.firstChild && b.removeChild(b.firstChild); b.appendChild(h.createTextNode(String(w(a), "").replace(/<[^>]*>/g, ""))) }, textSetter: function (a) { a !== this.textStr && (delete this.bBox, this.textStr = a, this.added && this.renderer.buildText(this)) }, fillSetter: function (a, b, p) {
                "string" === typeof a ? p.setAttribute(b,
                a) : a && this.colorGradient(a, b, p)
            }, visibilitySetter: function (a, b, p) { "inherit" === a ? p.removeAttribute(b) : p.setAttribute(b, a) }, zIndexSetter: function (a, b) { var p = this.renderer, e = this.parentGroup, B = (e || p).element || p.box, z, y = this.element, c; z = this.added; var q; t(a) && (y.zIndex = a, a = +a, this[b] === a && (z = !1), this[b] = a); if (z) { (a = this.zIndex) && e && (e.handleZ = !0); b = B.childNodes; for (q = 0; q < b.length && !c; q++) e = b[q], z = e.zIndex, e !== y && (K(z) > a || !t(a) && t(z) || 0 > a && !t(z) && B !== p.box) && (B.insertBefore(y, e), c = !0); c || B.appendChild(y) } return c },
            _defaultSetter: function (a, b, p) { p.setAttribute(b, a) }
        }; C.prototype.yGetter = C.prototype.xGetter; C.prototype.translateXSetter = C.prototype.translateYSetter = C.prototype.rotationSetter = C.prototype.verticalAlignSetter = C.prototype.scaleXSetter = C.prototype.scaleYSetter = function (a, b) { this[b] = a; this.doTransform = !0 }; C.prototype["stroke-widthSetter"] = C.prototype.strokeSetter = function (a, b, p) {
            this[b] = a; this.stroke && this["stroke-width"] ? (C.prototype.fillSetter.call(this, this.stroke, "stroke", p), p.setAttribute("stroke-width",
            this["stroke-width"]), this.hasStroke = !0) : "stroke-width" === b && 0 === a && this.hasStroke && (p.removeAttribute("stroke"), this.hasStroke = !1)
        }; A = a.SVGRenderer = function () { this.init.apply(this, arguments) }; A.prototype = {
            Element: C, SVG_NS: y, init: function (a, b, p, e, y, c) {
                var B; e = this.createElement("svg").attr({ version: "1.1", "class": "highcharts-root" }).css(this.getStyle(e)); B = e.element; a.appendChild(B); -1 === a.innerHTML.indexOf("xmlns") && k(B, "xmlns", this.SVG_NS); this.isSVG = !0; this.box = B; this.boxWrapper = e; this.alignedObjects =
                []; this.url = (I || L) && h.getElementsByTagName("base").length ? O.location.href.replace(/#.*?$/, "").replace(/([\('\)])/g, "\\$1").replace(/ /g, "%20") : ""; this.createElement("desc").add().element.appendChild(h.createTextNode("Created with Highcharts 5.0.3")); this.defs = this.createElement("defs").add(); this.allowHTML = c; this.forExport = y; this.gradients = {}; this.cache = {}; this.cacheKeys = []; this.imgCount = 0; this.setSize(b, p, !1); var z; I && a.getBoundingClientRect && (b = function () {
                    u(a, { left: 0, top: 0 }); z = a.getBoundingClientRect();
                    u(a, { left: Math.ceil(z.left) - z.left + "px", top: Math.ceil(z.top) - z.top + "px" })
                }, b(), this.unSubPixelFix = D(O, "resize", b))
            }, getStyle: function (a) { return this.style = H({ fontFamily: '"Lucida Grande", "Lucida Sans Unicode", Arial, Helvetica, sans-serif', fontSize: "12px" }, a) }, setStyle: function (a) { this.boxWrapper.css(this.getStyle(a)) }, isHidden: function () { return !this.boxWrapper.getBBox().width }, destroy: function () {
                var a = this.defs; this.box = null; this.boxWrapper = this.boxWrapper.destroy(); f(this.gradients || {}); this.gradients =
                null; a && (this.defs = a.destroy()); this.unSubPixelFix && this.unSubPixelFix(); return this.alignedObjects = null
            }, createElement: function (a) { var b = new this.Element; b.init(this, a); return b }, draw: J, getRadialAttr: function (a, b) { return { cx: a[0] - a[2] / 2 + b.cx * a[2], cy: a[1] - a[2] / 2 + b.cy * a[2], r: b.r * a[2] } }, buildText: function (a) {
                for (var b = a.element, c = this, B = c.forExport, q = w(a.textStr, "").toString(), f = -1 !== q.indexOf("\x3c"), m = b.childNodes, x, r, l, d, E = k(b, "x"), G = a.styles, t = a.textWidth, n = G && G.lineHeight, g = G && G.textOutline, L = G &&
                "ellipsis" === G.textOverflow, O = m.length, P = t && !a.added && this.box, H = function (a) { var p; p = /(px|em)$/.test(a && a.style.fontSize) ? a.style.fontSize : G && G.fontSize || c.style.fontSize || 12; return n ? K(n) : c.fontMetrics(p, a.getAttribute("style") ? a : b).h }; O--;) b.removeChild(m[O]); f || g || L || t || -1 !== q.indexOf(" ") ? (x = /<.*class="([^"]+)".*>/, r = /<.*style="([^"]+)".*>/, l = /<.*href="(http[^"]+)".*>/, P && P.appendChild(b), q = f ? q.replace(/<(b|strong)>/g, '\x3cspan style\x3d"font-weight:bold"\x3e').replace(/<(i|em)>/g, '\x3cspan style\x3d"font-style:italic"\x3e').replace(/<a/g,
                "\x3cspan").replace(/<\/(b|strong|i|em|a)>/g, "\x3c/span\x3e").split(/<br.*?>/g) : [q], q = e(q, function (a) { return "" !== a }), v(q, function (e, z) {
                    var q, f = 0; e = e.replace(/^\s+|\s+$/g, "").replace(/<span/g, "|||\x3cspan").replace(/<\/span>/g, "\x3c/span\x3e|||"); q = e.split("|||"); v(q, function (e) {
                        if ("" !== e || 1 === q.length) {
                            var m = {}, w = h.createElementNS(c.SVG_NS, "tspan"), v, S; x.test(e) && (v = e.match(x)[1], k(w, "class", v)); r.test(e) && (S = e.match(r)[1].replace(/(;| |^)color([ :])/, "$1fill$2"), k(w, "style", S)); l.test(e) && !B && (k(w,
                            "onclick", 'location.href\x3d"' + e.match(l)[1] + '"'), u(w, { cursor: "pointer" })); e = (e.replace(/<(.|\n)*?>/g, "") || " ").replace(/&lt;/g, "\x3c").replace(/&gt;/g, "\x3e"); if (" " !== e) {
                                w.appendChild(h.createTextNode(e)); f ? m.dx = 0 : z && null !== E && (m.x = E); k(w, m); b.appendChild(w); !f && z && (!p && B && u(w, { display: "block" }), k(w, "dy", H(w))); if (t) {
                                    m = e.replace(/([^\^])-/g, "$1- ").split(" "); v = "nowrap" === G.whiteSpace; for (var K = 1 < q.length || z || 1 < m.length && !v, g, n, O = [], R = H(w), P = a.rotation, Q = e, J = Q.length; (K || L) && (m.length || O.length) ;) a.rotation =
                                    0, g = a.getBBox(!0), n = g.width, !p && c.forExport && (n = c.measureSpanWidth(w.firstChild.data, a.styles)), g = n > t, void 0 === d && (d = g), L && d ? (J /= 2, "" === Q || !g && .5 > J ? m = [] : (Q = e.substring(0, Q.length + (g ? -1 : 1) * Math.ceil(J)), m = [Q + (3 < t ? "\u2026" : "")], w.removeChild(w.firstChild))) : g && 1 !== m.length ? (w.removeChild(w.firstChild), O.unshift(m.pop())) : (m = O, O = [], m.length && !v && (w = h.createElementNS(y, "tspan"), k(w, { dy: R, x: E }), S && k(w, "style", S), b.appendChild(w)), n > t && (t = n)), m.length && w.appendChild(h.createTextNode(m.join(" ").replace(/- /g,
                                    "-"))); a.rotation = P
                                } f++
                            }
                        }
                    })
                }), d && a.attr("title", a.textStr), P && P.removeChild(b), g && a.applyTextOutline && a.applyTextOutline(g)) : b.appendChild(h.createTextNode(q.replace(/&lt;/g, "\x3c").replace(/&gt;/g, "\x3e")))
            }, getContrast: function (a) { a = g(a).rgba; return 510 < a[0] + a[1] + a[2] ? "#000000" : "#FFFFFF" }, button: function (a, p, e, y, c, q, f, m, x) {
                var z = this.label(a, p, e, x, null, null, null, null, "button"), B = 0; z.attr(E({ padding: 8, r: 2 }, c)); var w, h, r, l; c = E({
                    fill: "#f7f7f7", stroke: "#cccccc", "stroke-width": 1, style: {
                        color: "#333333",
                        cursor: "pointer", fontWeight: "normal"
                    }
                }, c); w = c.style; delete c.style; q = E(c, { fill: "#e6e6e6" }, q); h = q.style; delete q.style; f = E(c, { fill: "#e6ebf5", style: { color: "#000000", fontWeight: "bold" } }, f); r = f.style; delete f.style; m = E(c, { style: { color: "#cccccc" } }, m); l = m.style; delete m.style; D(z.element, b ? "mouseover" : "mouseenter", function () { 3 !== B && z.setState(1) }); D(z.element, b ? "mouseout" : "mouseleave", function () { 3 !== B && z.setState(B) }); z.setState = function (a) {
                    1 !== a && (z.state = B = a); z.removeClass(/highcharts-button-(normal|hover|pressed|disabled)/).addClass("highcharts-button-" +
                    ["normal", "hover", "pressed", "disabled"][a || 0]); z.attr([c, q, f, m][a || 0]).css([w, h, r, l][a || 0])
                }; z.attr(c).css(H({ cursor: "default" }, w)); return z.on("click", function (a) { 3 !== B && y.call(z, a) })
            }, crispLine: function (a, b) { a[1] === a[4] && (a[1] = a[4] = Math.round(a[1]) - b % 2 / 2); a[2] === a[5] && (a[2] = a[5] = Math.round(a[2]) + b % 2 / 2); return a }, path: function (a) { var b = { fill: "none" }; r(a) ? b.d = a : q(a) && H(b, a); return this.createElement("path").attr(b) }, circle: function (a, b, p) {
                a = q(a) ? a : { x: a, y: b, r: p }; b = this.createElement("circle"); b.xSetter =
                b.ySetter = function (a, b, p) { p.setAttribute("c" + b, a) }; return b.attr(a)
            }, arc: function (a, b, p, e, c, y) { q(a) && (b = a.y, p = a.r, e = a.innerR, c = a.start, y = a.end, a = a.x); a = this.symbol("arc", a || 0, b || 0, p || 0, p || 0, { innerR: e || 0, start: c || 0, end: y || 0 }); a.r = p; return a }, rect: function (a, b, p, e, c, y) { c = q(a) ? a.r : c; var z = this.createElement("rect"); a = q(a) ? a : void 0 === a ? {} : { x: a, y: b, width: Math.max(p, 0), height: Math.max(e, 0) }; void 0 !== y && (a.strokeWidth = y, a = z.crisp(a)); a.fill = "none"; c && (a.r = c); z.rSetter = function (a, b, p) { k(p, { rx: a, ry: a }) }; return z.attr(a) },
            setSize: function (a, b, p) { var e = this.alignedObjects, c = e.length; this.width = a; this.height = b; for (this.boxWrapper.animate({ width: a, height: b }, { step: function () { this.attr({ viewBox: "0 0 " + this.attr("width") + " " + this.attr("height") }) }, duration: w(p, !0) ? void 0 : 0 }) ; c--;) e[c].align() }, g: function (a) { var b = this.createElement("g"); return a ? b.attr({ "class": "highcharts-" + a }) : b }, image: function (a, b, p, e, c) {
                var y = { preserveAspectRatio: "none" }; 1 < arguments.length && H(y, { x: b, y: p, width: e, height: c }); y = this.createElement("image").attr(y);
                y.element.setAttributeNS ? y.element.setAttributeNS("http://www.w3.org/1999/xlink", "href", a) : y.element.setAttribute("hc-svg-href", a); return y
            }, symbol: function (a, b, p, e, c, y) {
                var q = this, z, f = this.symbols[a], m = t(b) && f && f(Math.round(b), Math.round(p), e, c, y), B = /^url\((.*?)\)$/, x, r; f ? (z = this.path(m), z.attr("fill", "none"), H(z, { symbolName: a, x: b, y: p, width: e, height: c }), y && H(z, y)) : B.test(a) && (x = a.match(B)[1], z = this.image(x), z.imgwidth = w(P[x] && P[x].width, y && y.width), z.imgheight = w(P[x] && P[x].height, y && y.height), r =
                function () { z.attr({ width: z.width, height: z.height }) }, v(["width", "height"], function (a) { z[a + "Setter"] = function (a, b) { var p = {}, e = this["img" + b], y = "width" === b ? "translateX" : "translateY"; this[b] = a; t(e) && (this.element && this.element.setAttribute(b, e), this.alignByTranslate || (p[y] = ((this[b] || 0) - e) / 2, this.attr(p))) } }), t(b) && z.attr({ x: b, y: p }), z.isImg = !0, t(z.imgwidth) && t(z.imgheight) ? r() : (z.attr({ width: 0, height: 0 }), l("img", {
                    onload: function () {
                        var a = d[q.chartIndex]; 0 === this.width && (u(this, { position: "absolute", top: "-999em" }),
                        h.body.appendChild(this)); P[x] = { width: this.width, height: this.height }; z.imgwidth = this.width; z.imgheight = this.height; z.element && r(); this.parentNode && this.parentNode.removeChild(this); q.imgCount--; if (!q.imgCount && a && a.onload) a.onload()
                    }, src: x
                }), this.imgCount++)); return z
            }, symbols: {
                circle: function (a, b, p, e) { var y = .166 * p; return ["M", a + p / 2, b, "C", a + p + y, b, a + p + y, b + e, a + p / 2, b + e, "C", a - y, b + e, a - y, b, a + p / 2, b, "Z"] }, square: function (a, b, p, e) { return ["M", a, b, "L", a + p, b, a + p, b + e, a, b + e, "Z"] }, triangle: function (a, b, p, e) {
                    return ["M",
                    a + p / 2, b, "L", a + p, b + e, a, b + e, "Z"]
                }, "triangle-down": function (a, b, p, e) { return ["M", a, b, "L", a + p, b, a + p / 2, b + e, "Z"] }, diamond: function (a, b, p, e) { return ["M", a + p / 2, b, "L", a + p, b + e / 2, a + p / 2, b + e, a, b + e / 2, "Z"] }, arc: function (a, b, p, e, y) { var c = y.start; p = y.r || p || e; var q = y.end - .001; e = y.innerR; var f = y.open, z = Math.cos(c), m = Math.sin(c), x = Math.cos(q), q = Math.sin(q); y = y.end - c < Math.PI ? 0 : 1; return ["M", a + p * z, b + p * m, "A", p, p, 0, y, 1, a + p * x, b + p * q, f ? "M" : "L", a + e * x, b + e * q, "A", e, e, 0, y, 0, a + e * z, b + e * m, f ? "" : "Z"] }, callout: function (a, b, p, e, y) {
                    var c =
                    Math.min(y && y.r || 0, p, e), q = c + 6, f = y && y.anchorX; y = y && y.anchorY; var m; m = ["M", a + c, b, "L", a + p - c, b, "C", a + p, b, a + p, b, a + p, b + c, "L", a + p, b + e - c, "C", a + p, b + e, a + p, b + e, a + p - c, b + e, "L", a + c, b + e, "C", a, b + e, a, b + e, a, b + e - c, "L", a, b + c, "C", a, b, a, b, a + c, b]; f && f > p ? y > b + q && y < b + e - q ? m.splice(13, 3, "L", a + p, y - 6, a + p + 6, y, a + p, y + 6, a + p, b + e - c) : m.splice(13, 3, "L", a + p, e / 2, f, y, a + p, e / 2, a + p, b + e - c) : f && 0 > f ? y > b + q && y < b + e - q ? m.splice(33, 3, "L", a, y + 6, a - 6, y, a, y - 6, a, b + c) : m.splice(33, 3, "L", a, e / 2, f, y, a, e / 2, a, b + c) : y && y > e && f > a + q && f < a + p - q ? m.splice(23, 3, "L", f + 6, b +
                    e, f, b + e + 6, f - 6, b + e, a + c, b + e) : y && 0 > y && f > a + q && f < a + p - q && m.splice(3, 3, "L", f - 6, b, f, b - 6, f + 6, b, p - c, b); return m
                }
            }, clipRect: function (b, p, e, y) { var c = a.uniqueKey(), q = this.createElement("clipPath").attr({ id: c }).add(this.defs); b = this.rect(b, p, e, y, 0).add(q); b.id = c; b.clipPath = q; b.count = 0; return b }, text: function (a, b, e, y) {
                var c = !p && this.forExport, q = {}; if (y && (this.allowHTML || !this.forExport)) return this.html(a, b, e); q.x = Math.round(b || 0); e && (q.y = Math.round(e)); if (a || 0 === a) q.text = a; a = this.createElement("text").attr(q);
                c && a.css({ position: "absolute" }); y || (a.xSetter = function (a, b, p) { var e = p.getElementsByTagName("tspan"), y, c = p.getAttribute(b), q; for (q = 0; q < e.length; q++) y = e[q], y.getAttribute(b) === c && y.setAttribute(b, a); p.setAttribute(b, a) }); return a
            }, fontMetrics: function (a, b) { a = a || b && b.style && b.style.fontSize || this.style && this.style.fontSize; a = /px/.test(a) ? K(a) : /em/.test(a) ? parseFloat(a) * (b ? this.fontMetrics(null, b.parentNode).f : 16) : 12; b = 24 > a ? a + 3 : Math.round(1.2 * a); return { h: b, b: Math.round(.8 * b), f: a } }, rotCorr: function (a,
            b, p) { var e = a; b && p && (e = Math.max(e * Math.cos(b * n), 4)); return { x: -a / 3 * Math.sin(b * n), y: e } }, label: function (a, b, p, e, y, c, q, f, m) {
                var x = this, z = x.g("button" !== m && "label"), w = z.text = x.text("", 0, 0, q).attr({ zIndex: 1 }), h, r, l = 0, d = 3, B = 0, g, K, n, L, O, P = {}, k, J, S = /^url\((.*?)\)$/.test(e), I = S, N, u, R, Q; m && z.addClass("highcharts-" + m); I = S; N = function () { return (k || 0) % 2 / 2 }; u = function () {
                    var a = w.element.style, b = {}; r = (void 0 === g || void 0 === K || O) && t(w.textStr) && w.getBBox(); z.width = (g || r.width || 0) + 2 * d + B; z.height = (K || r.height || 0) + 2 * d; J =
                    d + x.fontMetrics(a && a.fontSize, w).b; I && (h || (z.box = h = x.symbols[e] || S ? x.symbol(e) : x.rect(), h.addClass(("button" === m ? "" : "highcharts-label-box") + (m ? " highcharts-" + m + "-box" : "")), h.add(z), a = N(), b.x = a, b.y = (f ? -J : 0) + a), b.width = Math.round(z.width), b.height = Math.round(z.height), h.attr(H(b, P)), P = {})
                }; R = function () { var a = B + d, b; b = f ? 0 : J; t(g) && r && ("center" === O || "right" === O) && (a += { center: .5, right: 1 }[O] * (g - r.width)); if (a !== w.x || b !== w.y) w.attr("x", a), void 0 !== b && w.attr("y", b); w.x = a; w.y = b }; Q = function (a, b) {
                    h ? h.attr(a, b) :
                    P[a] = b
                }; z.onAdd = function () { w.add(z); z.attr({ text: a || 0 === a ? a : "", x: b, y: p }); h && t(y) && z.attr({ anchorX: y, anchorY: c }) }; z.widthSetter = function (a) { g = a }; z.heightSetter = function (a) { K = a }; z["text-alignSetter"] = function (a) { O = a }; z.paddingSetter = function (a) { t(a) && a !== d && (d = z.padding = a, R()) }; z.paddingLeftSetter = function (a) { t(a) && a !== B && (B = a, R()) }; z.alignSetter = function (a) { a = { left: 0, center: .5, right: 1 }[a]; a !== l && (l = a, r && z.attr({ x: n })) }; z.textSetter = function (a) { void 0 !== a && w.textSetter(a); u(); R() }; z["stroke-widthSetter"] =
                function (a, b) { a && (I = !0); k = this["stroke-width"] = a; Q(b, a) }; z.strokeSetter = z.fillSetter = z.rSetter = function (a, b) { "fill" === b && a && (I = !0); Q(b, a) }; z.anchorXSetter = function (a, b) { y = a; Q(b, Math.round(a) - N() - n) }; z.anchorYSetter = function (a, b) { c = a; Q(b, a - L) }; z.xSetter = function (a) { z.x = a; l && (a -= l * ((g || r.width) + 2 * d)); n = Math.round(a); z.attr("translateX", n) }; z.ySetter = function (a) { L = z.y = Math.round(a); z.attr("translateY", L) }; var T = z.css; return H(z, {
                    css: function (a) {
                        if (a) {
                            var b = {}; a = E(a); v(z.textProps, function (p) {
                                void 0 !==
                                a[p] && (b[p] = a[p], delete a[p])
                            }); w.css(b)
                        } return T.call(z, a)
                    }, getBBox: function () { return { width: r.width + 2 * d, height: r.height + 2 * d, x: r.x - d, y: r.y - d } }, shadow: function (a) { a && (u(), h && h.shadow(a)); return z }, destroy: function () { G(z.element, "mouseenter"); G(z.element, "mouseleave"); w && (w = w.destroy()); h && (h = h.destroy()); C.prototype.destroy.call(z); z = x = u = R = Q = null }
                })
            }
        }; a.Renderer = A
    })(M); (function (a) {
        var C = a.attr, A = a.createElement, D = a.css, F = a.defined, k = a.each, d = a.extend, g = a.isFirefox, u = a.isMS, l = a.isWebKit, t = a.pInt, n =
        a.SVGRenderer, f = a.win, h = a.wrap; d(a.SVGElement.prototype, {
            htmlCss: function (a) { var f = this.element; if (f = a && "SPAN" === f.tagName && a.width) delete a.width, this.textWidth = f, this.updateTransform(); a && "ellipsis" === a.textOverflow && (a.whiteSpace = "nowrap", a.overflow = "hidden"); this.styles = d(this.styles, a); D(this.element, a); return this }, htmlGetBBox: function () { var a = this.element; "text" === a.nodeName && (a.style.position = "absolute"); return { x: a.offsetLeft, y: a.offsetTop, width: a.offsetWidth, height: a.offsetHeight } }, htmlUpdateTransform: function () {
                if (this.added) {
                    var a =
                    this.renderer, f = this.element, c = this.translateX || 0, e = this.translateY || 0, m = this.x || 0, h = this.y || 0, d = this.textAlign || "left", b = { left: 0, center: .5, right: 1 }[d], q = this.styles; D(f, { marginLeft: c, marginTop: e }); this.shadows && k(this.shadows, function (a) { D(a, { marginLeft: c + 1, marginTop: e + 1 }) }); this.inverted && k(f.childNodes, function (b) { a.invertChild(b, f) }); if ("SPAN" === f.tagName) {
                        var x = this.rotation, g = t(this.textWidth), E = q && q.whiteSpace, n = [x, d, f.innerHTML, this.textWidth, this.textAlign].join(); n !== this.cTT && (q = a.fontMetrics(f.style.fontSize).b,
                        F(x) && this.setSpanRotation(x, b, q), D(f, { width: "", whiteSpace: E || "nowrap" }), f.offsetWidth > g && /[ \-]/.test(f.textContent || f.innerText) && D(f, { width: g + "px", display: "block", whiteSpace: E || "normal" }), this.getSpanCorrection(f.offsetWidth, q, b, x, d)); D(f, { left: m + (this.xCorr || 0) + "px", top: h + (this.yCorr || 0) + "px" }); l && (q = f.offsetHeight); this.cTT = n
                    }
                } else this.alignOnAdd = !0
            }, setSpanRotation: function (a, h, c) {
                var e = {}, m = u ? "-ms-transform" : l ? "-webkit-transform" : g ? "MozTransform" : f.opera ? "-o-transform" : ""; e[m] = e.transform =
                "rotate(" + a + "deg)"; e[m + (g ? "Origin" : "-origin")] = e.transformOrigin = 100 * h + "% " + c + "px"; D(this.element, e)
            }, getSpanCorrection: function (a, f, c) { this.xCorr = -a * c; this.yCorr = -f }
        }); d(n.prototype, {
            html: function (a, f, c) {
                var e = this.createElement("span"), m = e.element, r = e.renderer, l = r.isSVG, b = function (a, b) { k(["opacity", "visibility"], function (e) { h(a, e + "Setter", function (a, e, c, q) { a.call(this, e, c, q); b[c] = e }) }) }; e.textSetter = function (a) { a !== m.innerHTML && delete this.bBox; m.innerHTML = this.textStr = a; e.htmlUpdateTransform() };
                l && b(e, e.element.style); e.xSetter = e.ySetter = e.alignSetter = e.rotationSetter = function (a, b) { "align" === b && (b = "textAlign"); e[b] = a; e.htmlUpdateTransform() }; e.attr({ text: a, x: Math.round(f), y: Math.round(c) }).css({ fontFamily: this.style.fontFamily, fontSize: this.style.fontSize, position: "absolute" }); m.style.whiteSpace = "nowrap"; e.css = e.htmlCss; l && (e.add = function (a) {
                    var c, f = r.box.parentNode, q = []; if (this.parentGroup = a) {
                        if (c = a.div, !c) {
                            for (; a;) q.push(a), a = a.parentGroup; k(q.reverse(), function (a) {
                                var e, q = C(a.element,
                                "class"); q && (q = { className: q }); c = a.div = a.div || A("div", q, { position: "absolute", left: (a.translateX || 0) + "px", top: (a.translateY || 0) + "px", display: a.display, opacity: a.opacity, pointerEvents: a.styles && a.styles.pointerEvents }, c || f); e = c.style; d(a, { translateXSetter: function (b, c) { e.left = b + "px"; a[c] = b; a.doTransform = !0 }, translateYSetter: function (b, c) { e.top = b + "px"; a[c] = b; a.doTransform = !0 } }); b(a, e)
                            })
                        }
                    } else c = f; c.appendChild(m); e.added = !0; e.alignOnAdd && e.htmlUpdateTransform(); return e
                }); return e
            }
        })
    })(M); (function (a) {
        var C,
        A, D = a.createElement, F = a.css, k = a.defined, d = a.deg2rad, g = a.discardElement, u = a.doc, l = a.each, t = a.erase, n = a.extend; C = a.extendClass; var f = a.isArray, h = a.isNumber, v = a.isObject, H = a.merge; A = a.noop; var c = a.pick, e = a.pInt, m = a.SVGElement, r = a.SVGRenderer, I = a.win; a.svg || (A = {
            docMode8: u && 8 === u.documentMode, init: function (a, e) {
                var b = ["\x3c", e, ' filled\x3d"f" stroked\x3d"f"'], c = ["position: ", "absolute", ";"], f = "div" === e; ("shape" === e || f) && c.push("left:0;top:0;width:1px;height:1px;"); c.push("visibility: ", f ? "hidden" : "visible");
                b.push(' style\x3d"', c.join(""), '"/\x3e'); e && (b = f || "span" === e || "img" === e ? b.join("") : a.prepVML(b), this.element = D(b)); this.renderer = a
            }, add: function (a) { var b = this.renderer, e = this.element, c = b.box, f = a && a.inverted, c = a ? a.element || a : c; a && (this.parentGroup = a); f && b.invertChild(e, c); c.appendChild(e); this.added = !0; this.alignOnAdd && !this.deferUpdateTransform && this.updateTransform(); if (this.onAdd) this.onAdd(); this.className && this.attr("class", this.className); return this }, updateTransform: m.prototype.htmlUpdateTransform,
            setSpanRotation: function () { var a = this.rotation, e = Math.cos(a * d), c = Math.sin(a * d); F(this.element, { filter: a ? ["progid:DXImageTransform.Microsoft.Matrix(M11\x3d", e, ", M12\x3d", -c, ", M21\x3d", c, ", M22\x3d", e, ", sizingMethod\x3d'auto expand')"].join("") : "none" }) }, getSpanCorrection: function (a, e, f, m, h) {
                var b = m ? Math.cos(m * d) : 1, q = m ? Math.sin(m * d) : 0, x = c(this.elemHeight, this.element.offsetHeight), r; this.xCorr = 0 > b && -a; this.yCorr = 0 > q && -x; r = 0 > b * q; this.xCorr += q * e * (r ? 1 - f : f); this.yCorr -= b * e * (m ? r ? f : 1 - f : 1); h && "left" !==
                h && (this.xCorr -= a * f * (0 > b ? -1 : 1), m && (this.yCorr -= x * f * (0 > q ? -1 : 1)), F(this.element, { textAlign: h }))
            }, pathToVML: function (a) { for (var b = a.length, e = []; b--;) h(a[b]) ? e[b] = Math.round(10 * a[b]) - 5 : "Z" === a[b] ? e[b] = "x" : (e[b] = a[b], !a.isArc || "wa" !== a[b] && "at" !== a[b] || (e[b + 5] === e[b + 7] && (e[b + 7] += a[b + 7] > a[b + 5] ? 1 : -1), e[b + 6] === e[b + 8] && (e[b + 8] += a[b + 8] > a[b + 6] ? 1 : -1))); return e.join(" ") || "x" }, clip: function (a) {
                var b = this, e; a ? (e = a.members, t(e, b), e.push(b), b.destroyClip = function () { t(e, b) }, a = a.getCSS(b)) : (b.destroyClip && b.destroyClip(),
                a = { clip: b.docMode8 ? "inherit" : "rect(auto)" }); return b.css(a)
            }, css: m.prototype.htmlCss, safeRemoveChild: function (a) { a.parentNode && g(a) }, destroy: function () { this.destroyClip && this.destroyClip(); return m.prototype.destroy.apply(this) }, on: function (a, e) { this.element["on" + a] = function () { var a = I.event; a.target = a.srcElement; e(a) }; return this }, cutOffPath: function (a, c) { var b; a = a.split(/[ ,]/); b = a.length; if (9 === b || 11 === b) a[b - 4] = a[b - 2] = e(a[b - 2]) - 10 * c; return a.join(" ") }, shadow: function (a, f, m) {
                var b = [], q, h = this.element,
                w = this.renderer, r, x = h.style, d, p = h.path, y, l, g, B; p && "string" !== typeof p.value && (p = "x"); l = p; if (a) {
                    g = c(a.width, 3); B = (a.opacity || .15) / g; for (q = 1; 3 >= q; q++) y = 2 * g + 1 - 2 * q, m && (l = this.cutOffPath(p.value, y + .5)), d = ['\x3cshape isShadow\x3d"true" strokeweight\x3d"', y, '" filled\x3d"false" path\x3d"', l, '" coordsize\x3d"10 10" style\x3d"', h.style.cssText, '" /\x3e'], r = D(w.prepVML(d), null, { left: e(x.left) + c(a.offsetX, 1), top: e(x.top) + c(a.offsetY, 1) }), m && (r.cutOff = y + 1), d = ['\x3cstroke color\x3d"', a.color || "#000000", '" opacity\x3d"',
                    B * q, '"/\x3e'], D(w.prepVML(d), null, null, r), f ? f.element.appendChild(r) : h.parentNode.insertBefore(r, h), b.push(r); this.shadows = b
                } return this
            }, updateShadows: A, setAttr: function (a, e) { this.docMode8 ? this.element[a] = e : this.element.setAttribute(a, e) }, classSetter: function (a) { (this.added ? this.element : this).className = a }, dashstyleSetter: function (a, e, c) { (c.getElementsByTagName("stroke")[0] || D(this.renderer.prepVML(["\x3cstroke/\x3e"]), null, null, c))[e] = a || "solid"; this[e] = a }, dSetter: function (a, e, c) {
                var b = this.shadows;
                a = a || []; this.d = a.join && a.join(" "); c.path = a = this.pathToVML(a); if (b) for (c = b.length; c--;) b[c].path = b[c].cutOff ? this.cutOffPath(a, b[c].cutOff) : a; this.setAttr(e, a)
            }, fillSetter: function (a, e, c) { var b = c.nodeName; "SPAN" === b ? c.style.color = a : "IMG" !== b && (c.filled = "none" !== a, this.setAttr("fillcolor", this.renderer.color(a, c, e, this))) }, "fill-opacitySetter": function (a, e, c) { D(this.renderer.prepVML(["\x3c", e.split("-")[0], ' opacity\x3d"', a, '"/\x3e']), null, null, c) }, opacitySetter: A, rotationSetter: function (a, e, c) {
                c =
                c.style; this[e] = c[e] = a; c.left = -Math.round(Math.sin(a * d) + 1) + "px"; c.top = Math.round(Math.cos(a * d)) + "px"
            }, strokeSetter: function (a, e, c) { this.setAttr("strokecolor", this.renderer.color(a, c, e, this)) }, "stroke-widthSetter": function (a, e, c) { c.stroked = !!a; this[e] = a; h(a) && (a += "px"); this.setAttr("strokeweight", a) }, titleSetter: function (a, e) { this.setAttr(e, a) }, visibilitySetter: function (a, e, c) {
                "inherit" === a && (a = "visible"); this.shadows && l(this.shadows, function (b) { b.style[e] = a }); "DIV" === c.nodeName && (a = "hidden" === a ? "-999em" :
                0, this.docMode8 || (c.style[e] = a ? "visible" : "hidden"), e = "top"); c.style[e] = a
            }, xSetter: function (a, e, c) { this[e] = a; "x" === e ? e = "left" : "y" === e && (e = "top"); this.updateClipping ? (this[e] = a, this.updateClipping()) : c.style[e] = a }, zIndexSetter: function (a, e, c) { c.style[e] = a }
        }, A["stroke-opacitySetter"] = A["fill-opacitySetter"], a.VMLElement = A = C(m, A), A.prototype.ySetter = A.prototype.widthSetter = A.prototype.heightSetter = A.prototype.xSetter, A = {
            Element: A, isIE8: -1 < I.navigator.userAgent.indexOf("MSIE 8.0"), init: function (a, e, c) {
                var b,
                f; this.alignedObjects = []; b = this.createElement("div").css({ position: "relative" }); f = b.element; a.appendChild(b.element); this.isVML = !0; this.box = f; this.boxWrapper = b; this.gradients = {}; this.cache = {}; this.cacheKeys = []; this.imgCount = 0; this.setSize(e, c, !1); if (!u.namespaces.hcv) { u.namespaces.add("hcv", "urn:schemas-microsoft-com:vml"); try { u.createStyleSheet().cssText = "hcv\\:fill, hcv\\:path, hcv\\:shape, hcv\\:stroke{ behavior:url(#default#VML); display: inline-block; } " } catch (J) { u.styleSheets[0].cssText += "hcv\\:fill, hcv\\:path, hcv\\:shape, hcv\\:stroke{ behavior:url(#default#VML); display: inline-block; } " } }
            },
            isHidden: function () { return !this.box.offsetWidth }, clipRect: function (a, e, c, f) {
                var b = this.createElement(), m = v(a); return n(b, {
                    members: [], count: 0, left: (m ? a.x : a) + 1, top: (m ? a.y : e) + 1, width: (m ? a.width : c) - 1, height: (m ? a.height : f) - 1, getCSS: function (a) {
                        var b = a.element, e = b.nodeName, c = a.inverted, p = this.top - ("shape" === e ? b.offsetTop : 0), y = this.left, b = y + this.width, f = p + this.height, p = { clip: "rect(" + Math.round(c ? y : p) + "px," + Math.round(c ? f : b) + "px," + Math.round(c ? b : f) + "px," + Math.round(c ? p : y) + "px)" }; !c && a.docMode8 && "DIV" === e &&
                        n(p, { width: b + "px", height: f + "px" }); return p
                    }, updateClipping: function () { l(b.members, function (a) { a.element && a.css(b.getCSS(a)) }) }
                })
            }, color: function (b, e, c, f) {
                var m = this, q, h = /^rgba/, r, d, x = "none"; b && b.linearGradient ? d = "gradient" : b && b.radialGradient && (d = "pattern"); if (d) {
                    var p, y, g = b.linearGradient || b.radialGradient, t, B, z, n, v, k = ""; b = b.stops; var L, I = [], H = function () {
                        r = ['\x3cfill colors\x3d"' + I.join(",") + '" opacity\x3d"', z, '" o:opacity2\x3d"', B, '" type\x3d"', d, '" ', k, 'focus\x3d"100%" method\x3d"any" /\x3e'];
                        D(m.prepVML(r), null, null, e)
                    }; t = b[0]; L = b[b.length - 1]; 0 < t[0] && b.unshift([0, t[1]]); 1 > L[0] && b.push([1, L[1]]); l(b, function (b, e) { h.test(b[1]) ? (q = a.color(b[1]), p = q.get("rgb"), y = q.get("a")) : (p = b[1], y = 1); I.push(100 * b[0] + "% " + p); e ? (z = y, n = p) : (B = y, v = p) }); if ("fill" === c) if ("gradient" === d) c = g.x1 || g[0] || 0, b = g.y1 || g[1] || 0, t = g.x2 || g[2] || 0, g = g.y2 || g[3] || 0, k = 'angle\x3d"' + (90 - 180 * Math.atan((g - b) / (t - c)) / Math.PI) + '"', H(); else {
                        var x = g.r, u = 2 * x, A = 2 * x, C = g.cx, F = g.cy, V = e.radialReference, U, x = function () {
                            V && (U = f.getBBox(), C += (V[0] -
                            U.x) / U.width - .5, F += (V[1] - U.y) / U.height - .5, u *= V[2] / U.width, A *= V[2] / U.height); k = 'src\x3d"' + a.getOptions().global.VMLRadialGradientURL + '" size\x3d"' + u + "," + A + '" origin\x3d"0.5,0.5" position\x3d"' + C + "," + F + '" color2\x3d"' + v + '" '; H()
                        }; f.added ? x() : f.onAdd = x; x = n
                    } else x = p
                } else h.test(b) && "IMG" !== e.tagName ? (q = a.color(b), f[c + "-opacitySetter"](q.get("a"), c, e), x = q.get("rgb")) : (x = e.getElementsByTagName(c), x.length && (x[0].opacity = 1, x[0].type = "solid"), x = b); return x
            }, prepVML: function (a) {
                var b = this.isIE8; a = a.join("");
                b ? (a = a.replace("/\x3e", ' xmlns\x3d"urn:schemas-microsoft-com:vml" /\x3e'), a = -1 === a.indexOf('style\x3d"') ? a.replace("/\x3e", ' style\x3d"display:inline-block;behavior:url(#default#VML);" /\x3e') : a.replace('style\x3d"', 'style\x3d"display:inline-block;behavior:url(#default#VML);')) : a = a.replace("\x3c", "\x3chcv:"); return a
            }, text: r.prototype.html, path: function (a) { var b = { coordsize: "10 10" }; f(a) ? b.d = a : v(a) && n(b, a); return this.createElement("shape").attr(b) }, circle: function (a, e, c) {
                var b = this.symbol("circle");
                v(a) && (c = a.r, e = a.y, a = a.x); b.isCircle = !0; b.r = c; return b.attr({ x: a, y: e })
            }, g: function (a) { var b; a && (b = { className: "highcharts-" + a, "class": "highcharts-" + a }); return this.createElement("div").attr(b) }, image: function (a, e, c, f, m) { var b = this.createElement("img").attr({ src: a }); 1 < arguments.length && b.attr({ x: e, y: c, width: f, height: m }); return b }, createElement: function (a) { return "rect" === a ? this.symbol(a) : r.prototype.createElement.call(this, a) }, invertChild: function (a, c) {
                var b = this; c = c.style; var f = "IMG" === a.tagName && a.style;
                F(a, { flip: "x", left: e(c.width) - (f ? e(f.top) : 1), top: e(c.height) - (f ? e(f.left) : 1), rotation: -90 }); l(a.childNodes, function (e) { b.invertChild(e, a) })
            }, symbols: {
                arc: function (a, e, c, f, m) { var b = m.start, h = m.end, r = m.r || c || f; c = m.innerR; f = Math.cos(b); var q = Math.sin(b), d = Math.cos(h), p = Math.sin(h); if (0 === h - b) return ["x"]; b = ["wa", a - r, e - r, a + r, e + r, a + r * f, e + r * q, a + r * d, e + r * p]; m.open && !c && b.push("e", "M", a, e); b.push("at", a - c, e - c, a + c, e + c, a + c * d, e + c * p, a + c * f, e + c * q, "x", "e"); b.isArc = !0; return b }, circle: function (a, e, c, f, m) {
                    m && k(m.r) &&
                    (c = f = 2 * m.r); m && m.isCircle && (a -= c / 2, e -= f / 2); return ["wa", a, e, a + c, e + f, a + c, e + f / 2, a + c, e + f / 2, "e"]
                }, rect: function (a, e, c, f, m) { return r.prototype.symbols[k(m) && m.r ? "callout" : "square"].call(0, a, e, c, f, m) }
            }
        }, a.VMLRenderer = C = function () { this.init.apply(this, arguments) }, C.prototype = H(r.prototype, A), a.Renderer = C); r.prototype.measureSpanWidth = function (a, e) { var b = u.createElement("span"); a = u.createTextNode(a); b.appendChild(a); F(b, e); this.box.appendChild(b); e = b.offsetWidth; g(b); return e }
    })(M); (function (a) {
        function C() {
            var k =
            a.defaultOptions.global, l, t = k.useUTC, n = t ? "getUTC" : "get", f = t ? "setUTC" : "set"; a.Date = l = k.Date || g.Date; l.hcTimezoneOffset = t && k.timezoneOffset; l.hcGetTimezoneOffset = t && k.getTimezoneOffset; l.hcMakeTime = function (a, f, g, c, e, m) { var h; t ? (h = l.UTC.apply(0, arguments), h += F(h)) : h = (new l(a, f, d(g, 1), d(c, 0), d(e, 0), d(m, 0))).getTime(); return h }; D("Minutes Hours Day Date Month FullYear".split(" "), function (a) { l["hcGet" + a] = n + a }); D("Milliseconds Seconds Minutes Hours Date Month FullYear".split(" "), function (a) {
                l["hcSet" +
                a] = f + a
            })
        } var A = a.color, D = a.each, F = a.getTZOffset, k = a.merge, d = a.pick, g = a.win; a.defaultOptions = {
            colors: "#7cb5ec #434348 #90ed7d #f7a35c #8085e9 #f15c80 #e4d354 #2b908f #f45b5b #91e8e1".split(" "), symbols: ["circle", "diamond", "square", "triangle", "triangle-down"], lang: {
                loading: "Loading...", months: "January February March April May June July August September October November December".split(" "), shortMonths: "Jan Feb Mar Apr May Jun Jul Aug Sep Oct Nov Dec".split(" "), weekdays: "Sunday Monday Tuesday Wednesday Thursday Friday Saturday".split(" "),
                decimalPoint: ".", numericSymbols: "kMGTPE".split(""), resetZoom: "Reset zoom", resetZoomTitle: "Reset zoom level 1:1", thousandsSep: " "
            }, global: { useUTC: !0, VMLRadialGradientURL: "http://code.highcharts.com/5.0.3/gfx/vml-radial-gradient.png" }, chart: { borderRadius: 0, defaultSeriesType: "line", ignoreHiddenSeries: !0, spacing: [10, 10, 15, 10], resetZoomButton: { theme: { zIndex: 20 }, position: { align: "right", x: -10, y: 10 } }, width: null, height: null, borderColor: "#335cad", backgroundColor: "#ffffff", plotBorderColor: "#cccccc" }, title: {
                text: "Chart title",
                align: "center", margin: 15, style: { color: "#333333", fontSize: "18px" }, widthAdjust: -44
            }, subtitle: { text: "", align: "center", style: { color: "#666666" }, widthAdjust: -44 }, plotOptions: {}, labels: { style: { position: "absolute", color: "#333333" } }, legend: {
                enabled: !0, align: "center", layout: "horizontal", labelFormatter: function () { return this.name }, borderColor: "#999999", borderRadius: 0, navigation: { activeColor: "#003399", inactiveColor: "#cccccc" }, itemStyle: { color: "#333333", fontSize: "12px", fontWeight: "bold" }, itemHoverStyle: { color: "#000000" },
                itemHiddenStyle: { color: "#cccccc" }, shadow: !1, itemCheckboxStyle: { position: "absolute", width: "13px", height: "13px" }, squareSymbol: !0, symbolPadding: 5, verticalAlign: "bottom", x: 0, y: 0, title: { style: { fontWeight: "bold" } }
            }, loading: { labelStyle: { fontWeight: "bold", position: "relative", top: "45%" }, style: { position: "absolute", backgroundColor: "#ffffff", opacity: .5, textAlign: "center" } }, tooltip: {
                enabled: !0, animation: a.svg, borderRadius: 3, dateTimeLabelFormats: {
                    millisecond: "%A, %b %e, %H:%M:%S.%L", second: "%A, %b %e, %H:%M:%S",
                    minute: "%A, %b %e, %H:%M", hour: "%A, %b %e, %H:%M", day: "%A, %b %e, %Y", week: "Week from %A, %b %e, %Y", month: "%B %Y", year: "%Y"
                }, footerFormat: "", padding: 8, snap: a.isTouchDevice ? 25 : 10, backgroundColor: A("#f7f7f7").setOpacity(.85).get(), borderWidth: 1, headerFormat: '\x3cspan style\x3d"font-size: 10px"\x3e{point.key}\x3c/span\x3e\x3cbr/\x3e', pointFormat: '\x3cspan style\x3d"color:{point.color}"\x3e\u25cf\x3c/span\x3e {series.name}: \x3cb\x3e{point.y}\x3c/b\x3e\x3cbr/\x3e', shadow: !0, style: {
                    color: "#333333", cursor: "default",
                    fontSize: "12px", pointerEvents: "none", whiteSpace: "nowrap"
                }
            }, credits: { enabled: !0, href: "http://www.highcharts.com", position: { align: "right", x: -10, verticalAlign: "bottom", y: -5 }, style: { cursor: "pointer", color: "#999999", fontSize: "9px" }, text: "Highcharts.com" }
        }; a.setOptions = function (d) { a.defaultOptions = k(!0, a.defaultOptions, d); C(); return a.defaultOptions }; a.getOptions = function () { return a.defaultOptions }; a.defaultPlotOptions = a.defaultOptions.plotOptions; C()
    })(M); (function (a) {
        var C = a.arrayMax, A = a.arrayMin, D = a.defined,
        F = a.destroyObjectProperties, k = a.each, d = a.erase, g = a.merge, u = a.pick; a.PlotLineOrBand = function (a, d) { this.axis = a; d && (this.options = d, this.id = d.id) }; a.PlotLineOrBand.prototype = {
            render: function () {
                var a = this, d = a.axis, n = d.horiz, f = a.options, h = f.label, v = a.label, k = f.to, c = f.from, e = f.value, m = D(c) && D(k), r = D(e), I = a.svgElem, b = !I, q = [], x, L = f.color, E = u(f.zIndex, 0), J = f.events, q = { "class": "highcharts-plot-" + (m ? "band " : "line ") + (f.className || "") }, w = {}, K = d.chart.renderer, G = m ? "bands" : "lines", N = d.log2lin; d.isLog && (c = N(c), k =
                N(k), e = N(e)); r ? (q = { stroke: L, "stroke-width": f.width }, f.dashStyle && (q.dashstyle = f.dashStyle)) : m && (L && (q.fill = L), f.borderWidth && (q.stroke = f.borderColor, q["stroke-width"] = f.borderWidth)); w.zIndex = E; G += "-" + E; (L = d[G]) || (d[G] = L = K.g("plot-" + G).attr(w).add()); b && (a.svgElem = I = K.path().attr(q).add(L)); if (r) q = d.getPlotLinePath(e, I.strokeWidth()); else if (m) q = d.getPlotBandPath(c, k, f); else return; if (b && q && q.length) { if (I.attr({ d: q }), J) for (x in f = function (b) { I.on(b, function (e) { J[b].apply(a, [e]) }) }, J) f(x) } else I &&
                (q ? (I.show(), I.animate({ d: q })) : (I.hide(), v && (a.label = v = v.destroy()))); h && D(h.text) && q && q.length && 0 < d.width && 0 < d.height && !q.flat ? (h = g({ align: n && m && "center", x: n ? !m && 4 : 10, verticalAlign: !n && m && "middle", y: n ? m ? 16 : 10 : m ? 6 : -4, rotation: n && !m && 90 }, h), this.renderLabel(h, q, m, E)) : v && v.hide(); return a
            }, renderLabel: function (a, d, g, f) {
                var h = this.label, l = this.axis.chart.renderer; h || (h = { align: a.textAlign || a.align, rotation: a.rotation, "class": "highcharts-plot-" + (g ? "band" : "line") + "-label " + (a.className || "") }, h.zIndex = f,
                this.label = h = l.text(a.text, 0, 0, a.useHTML).attr(h).add(), h.css(a.style)); f = [d[1], d[4], g ? d[6] : d[1]]; d = [d[2], d[5], g ? d[7] : d[2]]; g = A(f); l = A(d); h.align(a, !1, { x: g, y: l, width: C(f) - g, height: C(d) - l }); h.show()
            }, destroy: function () { d(this.axis.plotLinesAndBands, this); delete this.axis; F(this) }
        }; a.AxisPlotLineOrBandExtension = {
            getPlotBandPath: function (a, d) {
                d = this.getPlotLinePath(d, null, null, !0); (a = this.getPlotLinePath(a, null, null, !0)) && d ? (a.flat = a.toString() === d.toString(), a.push(d[4], d[5], d[1], d[2], "z")) : a = null;
                return a
            }, addPlotBand: function (a) { return this.addPlotBandOrLine(a, "plotBands") }, addPlotLine: function (a) { return this.addPlotBandOrLine(a, "plotLines") }, addPlotBandOrLine: function (d, g) { var l = (new a.PlotLineOrBand(this, d)).render(), f = this.userOptions; l && (g && (f[g] = f[g] || [], f[g].push(d)), this.plotLinesAndBands.push(l)); return l }, removePlotBandOrLine: function (a) {
                for (var g = this.plotLinesAndBands, l = this.options, f = this.userOptions, h = g.length; h--;) g[h].id === a && g[h].destroy(); k([l.plotLines || [], f.plotLines ||
                [], l.plotBands || [], f.plotBands || []], function (f) { for (h = f.length; h--;) f[h].id === a && d(f, f[h]) })
            }
        }
    })(M); (function (a) {
        var C = a.correctFloat, A = a.defined, D = a.destroyObjectProperties, F = a.isNumber, k = a.merge, d = a.pick, g = a.stop, u = a.deg2rad; a.Tick = function (a, d, g, f) { this.axis = a; this.pos = d; this.type = g || ""; this.isNew = !0; g || f || this.addLabel() }; a.Tick.prototype = {
            addLabel: function () {
                var a = this.axis, g = a.options, n = a.chart, f = a.categories, h = a.names, v = this.pos, H = g.labels, c = a.tickPositions, e = v === c[0], m = v === c[c.length - 1], h =
                f ? d(f[v], h[v], v) : v, f = this.label, c = c.info, r; a.isDatetimeAxis && c && (r = g.dateTimeLabelFormats[c.higherRanks[v] || c.unitName]); this.isFirst = e; this.isLast = m; g = a.labelFormatter.call({ axis: a, chart: n, isFirst: e, isLast: m, dateTimeLabelFormat: r, value: a.isLog ? C(a.lin2log(h)) : h }); A(f) ? f && f.attr({ text: g }) : (this.labelLength = (this.label = f = A(g) && H.enabled ? n.renderer.text(g, 0, 0, H.useHTML).css(k(H.style)).add(a.labelGroup) : null) && f.getBBox().width, this.rotation = 0)
            }, getLabelSize: function () {
                return this.label ? this.label.getBBox()[this.axis.horiz ?
                "height" : "width"] : 0
            }, handleOverflow: function (a) {
                var g = this.axis, l = a.x, f = g.chart.chartWidth, h = g.chart.spacing, v = d(g.labelLeft, Math.min(g.pos, h[3])), h = d(g.labelRight, Math.max(g.pos + g.len, f - h[1])), k = this.label, c = this.rotation, e = { left: 0, center: .5, right: 1 }[g.labelAlign], m = k.getBBox().width, r = g.getSlotWidth(), I = r, b = 1, q, x = {}; if (c) 0 > c && l - e * m < v ? q = Math.round(l / Math.cos(c * u) - v) : 0 < c && l + e * m > h && (q = Math.round((f - l) / Math.cos(c * u))); else if (f = l + (1 - e) * m, l - e * m < v ? I = a.x + I * (1 - e) - v : f > h && (I = h - a.x + I * e, b = -1), I = Math.min(r,
                I), I < r && "center" === g.labelAlign && (a.x += b * (r - I - e * (r - Math.min(m, I)))), m > I || g.autoRotation && (k.styles || {}).width) q = I; q && (x.width = q, (g.options.labels.style || {}).textOverflow || (x.textOverflow = "ellipsis"), k.css(x))
            }, getPosition: function (a, d, g, f) {
                var h = this.axis, l = h.chart, n = f && l.oldChartHeight || l.chartHeight; return {
                    x: a ? h.translate(d + g, null, null, f) + h.transB : h.left + h.offset + (h.opposite ? (f && l.oldChartWidth || l.chartWidth) - h.right - h.left : 0), y: a ? n - h.bottom + h.offset - (h.opposite ? h.height : 0) : n - h.translate(d + g, null,
                    null, f) - h.transB
                }
            }, getLabelPosition: function (a, d, g, f, h, v, k, c) { var e = this.axis, m = e.transA, r = e.reversed, l = e.staggerLines, b = e.tickRotCorr || { x: 0, y: 0 }, q = h.y; A(q) || (q = 0 === e.side ? g.rotation ? -8 : -g.getBBox().height : 2 === e.side ? b.y + 8 : Math.cos(g.rotation * u) * (b.y - g.getBBox(!1, 0).height / 2)); a = a + h.x + b.x - (v && f ? v * m * (r ? -1 : 1) : 0); d = d + q - (v && !f ? v * m * (r ? 1 : -1) : 0); l && (g = k / (c || 1) % l, e.opposite && (g = l - g - 1), d += e.labelOffset / l * g); return { x: a, y: Math.round(d) } }, getMarkPath: function (a, d, g, f, h, v) {
                return v.crispLine(["M", a, d, "L", a + (h ?
                0 : -g), d + (h ? g : 0)], f)
            }, render: function (a, k, n) {
                var f = this.axis, h = f.options, l = f.chart.renderer, t = f.horiz, c = this.type, e = this.label, m = this.pos, r = h.labels, I = this.gridLine, b = c ? c + "Tick" : "tick", q = f.tickSize(b), x = this.mark, L = !x, E = r.step, u = {}, w = !0, K = f.tickmarkOffset, G = this.getPosition(t, m, K, k), N = G.x, G = G.y, p = t && N === f.pos + f.len || !t && G === f.pos ? -1 : 1, y = c ? c + "Grid" : "grid", P = h[y + "LineWidth"], O = h[y + "LineColor"], B = h[y + "LineDashStyle"], y = d(h[b + "Width"], !c && f.isXAxis ? 1 : 0), b = h[b + "Color"]; n = d(n, 1); this.isActive = !0; I || (u.stroke =
                O, u["stroke-width"] = P, B && (u.dashstyle = B), c || (u.zIndex = 1), k && (u.opacity = 0), this.gridLine = I = l.path().attr(u).addClass("highcharts-" + (c ? c + "-" : "") + "grid-line").add(f.gridGroup)); if (!k && I && (m = f.getPlotLinePath(m + K, I.strokeWidth() * p, k, !0))) I[this.isNew ? "attr" : "animate"]({ d: m, opacity: n }); q && (f.opposite && (q[0] = -q[0]), L && (this.mark = x = l.path().addClass("highcharts-" + (c ? c + "-" : "") + "tick").add(f.axisGroup), x.attr({ stroke: b, "stroke-width": y })), x[L ? "attr" : "animate"]({
                    d: this.getMarkPath(N, G, q[0], x.strokeWidth() *
                    p, t, l), opacity: n
                })); e && F(N) && (e.xy = G = this.getLabelPosition(N, G, e, t, r, K, a, E), this.isFirst && !this.isLast && !d(h.showFirstLabel, 1) || this.isLast && !this.isFirst && !d(h.showLastLabel, 1) ? w = !1 : !t || f.isRadial || r.step || r.rotation || k || 0 === n || this.handleOverflow(G), E && a % E && (w = !1), w && F(G.y) ? (G.opacity = n, e[this.isNew ? "attr" : "animate"](G)) : (g(e), e.attr("y", -9999)), this.isNew = !1)
            }, destroy: function () { D(this, this.axis) }
        }
    })(M); (function (a) {
        var C = a.addEvent, A = a.animObject, D = a.arrayMax, F = a.arrayMin, k = a.AxisPlotLineOrBandExtension,
        d = a.color, g = a.correctFloat, u = a.defaultOptions, l = a.defined, t = a.deg2rad, n = a.destroyObjectProperties, f = a.each, h = a.error, v = a.extend, H = a.fireEvent, c = a.format, e = a.getMagnitude, m = a.grep, r = a.inArray, I = a.isArray, b = a.isNumber, q = a.isString, x = a.merge, L = a.normalizeTickInterval, E = a.pick, J = a.PlotLineOrBand, w = a.removeEvent, K = a.splat, G = a.syncTimeout, N = a.Tick; a.Axis = function () { this.init.apply(this, arguments) }; a.Axis.prototype = {
            defaultOptions: {
                dateTimeLabelFormats: {
                    millisecond: "%H:%M:%S.%L", second: "%H:%M:%S", minute: "%H:%M",
                    hour: "%H:%M", day: "%e. %b", week: "%e. %b", month: "%b '%y", year: "%Y"
                }, endOnTick: !1, labels: { enabled: !0, style: { color: "#666666", cursor: "default", fontSize: "11px" }, x: 0 }, minPadding: .01, maxPadding: .01, minorTickLength: 2, minorTickPosition: "outside", startOfWeek: 1, startOnTick: !1, tickLength: 10, tickmarkPlacement: "between", tickPixelInterval: 100, tickPosition: "outside", title: { align: "middle", style: { color: "#666666" } }, type: "linear", minorGridLineColor: "#f2f2f2", minorGridLineWidth: 1, minorTickColor: "#999999", lineColor: "#ccd6eb",
                lineWidth: 1, gridLineColor: "#e6e6e6", tickColor: "#ccd6eb"
            }, defaultYAxisOptions: { endOnTick: !0, tickPixelInterval: 72, showLastLabel: !0, labels: { x: -8 }, maxPadding: .05, minPadding: .05, startOnTick: !0, title: { rotation: 270, text: "Values" }, stackLabels: { enabled: !1, formatter: function () { return a.numberFormat(this.total, -1) }, style: { fontSize: "11px", fontWeight: "bold", color: "#000000", textOutline: "1px contrast" } }, gridLineWidth: 1, lineWidth: 0 }, defaultLeftAxisOptions: { labels: { x: -15 }, title: { rotation: 270 } }, defaultRightAxisOptions: {
                labels: { x: 15 },
                title: { rotation: 90 }
            }, defaultBottomAxisOptions: { labels: { autoRotation: [-45], x: 0 }, title: { rotation: 0 } }, defaultTopAxisOptions: { labels: { autoRotation: [-45], x: 0 }, title: { rotation: 0 } }, init: function (a, b) {
                var e = b.isX; this.chart = a; this.horiz = a.inverted ? !e : e; this.isXAxis = e; this.coll = this.coll || (e ? "xAxis" : "yAxis"); this.opposite = b.opposite; this.side = b.side || (this.horiz ? this.opposite ? 0 : 2 : this.opposite ? 1 : 3); this.setOptions(b); var p = this.options, c = p.type; this.labelFormatter = p.labels.formatter || this.defaultLabelFormatter;
                this.userOptions = b; this.minPixelPadding = 0; this.reversed = p.reversed; this.visible = !1 !== p.visible; this.zoomEnabled = !1 !== p.zoomEnabled; this.hasNames = "category" === c || !0 === p.categories; this.categories = p.categories || this.hasNames; this.names = this.names || []; this.isLog = "logarithmic" === c; this.isDatetimeAxis = "datetime" === c; this.isLinked = l(p.linkedTo); this.ticks = {}; this.labelEdge = []; this.minorTicks = {}; this.plotLinesAndBands = []; this.alternateBands = {}; this.len = 0; this.minRange = this.userMinRange = p.minRange || p.maxZoom;
                this.range = p.range; this.offset = p.offset || 0; this.stacks = {}; this.oldStacks = {}; this.stacksTouched = 0; this.min = this.max = null; this.crosshair = E(p.crosshair, K(a.options.tooltip.crosshairs)[e ? 0 : 1], !1); var f; b = this.options.events; -1 === r(this, a.axes) && (e ? a.axes.splice(a.xAxis.length, 0, this) : a.axes.push(this), a[this.coll].push(this)); this.series = this.series || []; a.inverted && e && void 0 === this.reversed && (this.reversed = !0); this.removePlotLine = this.removePlotBand = this.removePlotBandOrLine; for (f in b) C(this, f, b[f]);
                this.isLog && (this.val2lin = this.log2lin, this.lin2val = this.lin2log)
            }, setOptions: function (a) { this.options = x(this.defaultOptions, "yAxis" === this.coll && this.defaultYAxisOptions, [this.defaultTopAxisOptions, this.defaultRightAxisOptions, this.defaultBottomAxisOptions, this.defaultLeftAxisOptions][this.side], x(u[this.coll], a)) }, defaultLabelFormatter: function () {
                var b = this.axis, e = this.value, f = b.categories, m = this.dateTimeLabelFormat, h = u.lang, z = h.numericSymbols, h = h.numericSymbolMagnitude || 1E3, d = z && z.length, r, q = b.options.labels.format,
                b = b.isLog ? e : b.tickInterval; if (q) r = c(q, this); else if (f) r = e; else if (m) r = a.dateFormat(m, e); else if (d && 1E3 <= b) for (; d-- && void 0 === r;) f = Math.pow(h, d + 1), b >= f && 0 === 10 * e % f && null !== z[d] && 0 !== e && (r = a.numberFormat(e / f, -1) + z[d]); void 0 === r && (r = 1E4 <= Math.abs(e) ? a.numberFormat(e, -1) : a.numberFormat(e, -1, void 0, "")); return r
            }, getSeriesExtremes: function () {
                var a = this, e = a.chart; a.hasVisibleSeries = !1; a.dataMin = a.dataMax = a.threshold = null; a.softThreshold = !a.isXAxis; a.buildStacks && a.buildStacks(); f(a.series, function (c) {
                    if (c.visible ||
                    !e.options.chart.ignoreHiddenSeries) {
                        var p = c.options, f = p.threshold, y; a.hasVisibleSeries = !0; a.isLog && 0 >= f && (f = null); if (a.isXAxis) p = c.xData, p.length && (c = F(p), b(c) || c instanceof Date || (p = m(p, function (a) { return b(a) }), c = F(p)), a.dataMin = Math.min(E(a.dataMin, p[0]), c), a.dataMax = Math.max(E(a.dataMax, p[0]), D(p))); else if (c.getExtremes(), y = c.dataMax, c = c.dataMin, l(c) && l(y) && (a.dataMin = Math.min(E(a.dataMin, c), c), a.dataMax = Math.max(E(a.dataMax, y), y)), l(f) && (a.threshold = f), !p.softThreshold || a.isLog) a.softThreshold =
                        !1
                    }
                })
            }, translate: function (a, e, c, f, m, z) { var p = this.linkedParent || this, y = 1, h = 0, d = f ? p.oldTransA : p.transA; f = f ? p.oldMin : p.min; var r = p.minPixelPadding; m = (p.isOrdinal || p.isBroken || p.isLog && m) && p.lin2val; d || (d = p.transA); c && (y *= -1, h = p.len); p.reversed && (y *= -1, h -= y * (p.sector || p.len)); e ? (a = (a * y + h - r) / d + f, m && (a = p.lin2val(a))) : (m && (a = p.val2lin(a)), a = y * (a - f) * d + h + y * r + (b(z) ? d * z : 0)); return a }, toPixels: function (a, b) { return this.translate(a, !1, !this.horiz, null, !0) + (b ? 0 : this.pos) }, toValue: function (a, b) {
                return this.translate(a -
                (b ? 0 : this.pos), !0, !this.horiz, null, !0)
            }, getPlotLinePath: function (a, e, c, f, m) {
                var p = this.chart, y = this.left, h = this.top, d, r, q = c && p.oldChartHeight || p.chartHeight, w = c && p.oldChartWidth || p.chartWidth, g; d = this.transB; var x = function (a, b, e) { if (a < b || a > e) f ? a = Math.min(Math.max(b, a), e) : g = !0; return a }; m = E(m, this.translate(a, null, null, c)); a = c = Math.round(m + d); d = r = Math.round(q - m - d); b(m) ? this.horiz ? (d = h, r = q - this.bottom, a = c = x(a, y, y + this.width)) : (a = y, c = w - this.right, d = r = x(d, h, h + this.height)) : g = !0; return g && !f ? null : p.renderer.crispLine(["M",
                a, d, "L", c, r], e || 1)
            }, getLinearTickPositions: function (a, e, c) { var p, f = g(Math.floor(e / a) * a), y = g(Math.ceil(c / a) * a), m = []; if (e === c && b(e)) return [e]; for (e = f; e <= y;) { m.push(e); e = g(e + a); if (e === p) break; p = e } return m }, getMinorTickPositions: function () {
                var a = this.options, b = this.tickPositions, e = this.minorTickInterval, c = [], f, m = this.pointRangePadding || 0; f = this.min - m; var m = this.max + m, d = m - f; if (d && d / e < this.len / 3) if (this.isLog) for (m = b.length, f = 1; f < m; f++) c = c.concat(this.getLogTickPositions(e, b[f - 1], b[f], !0)); else if (this.isDatetimeAxis &&
                "auto" === a.minorTickInterval) c = c.concat(this.getTimeTicks(this.normalizeTimeTickInterval(e), f, m, a.startOfWeek)); else for (b = f + (b[0] - f) % e; b <= m && b !== c[0]; b += e) c.push(b); 0 !== c.length && this.trimTicks(c, a.startOnTick, a.endOnTick); return c
            }, adjustForMinRange: function () {
                var a = this.options, b = this.min, e = this.max, c, m = this.dataMax - this.dataMin >= this.minRange, d, h, r, q, g, w; this.isXAxis && void 0 === this.minRange && !this.isLog && (l(a.min) || l(a.max) ? this.minRange = null : (f(this.series, function (a) {
                    q = a.xData; for (h = g = a.xIncrement ?
                    1 : q.length - 1; 0 < h; h--) if (r = q[h] - q[h - 1], void 0 === d || r < d) d = r
                }), this.minRange = Math.min(5 * d, this.dataMax - this.dataMin))); e - b < this.minRange && (w = this.minRange, c = (w - e + b) / 2, c = [b - c, E(a.min, b - c)], m && (c[2] = this.isLog ? this.log2lin(this.dataMin) : this.dataMin), b = D(c), e = [b + w, E(a.max, b + w)], m && (e[2] = this.isLog ? this.log2lin(this.dataMax) : this.dataMax), e = F(e), e - b < w && (c[0] = e - w, c[1] = E(a.min, e - w), b = D(c))); this.min = b; this.max = e
            }, getClosest: function () {
                var a; this.categories ? a = 1 : f(this.series, function (b) {
                    var e = b.closestPointRange,
                    c = b.visible || !b.chart.options.chart.ignoreHiddenSeries; !b.noSharedTooltip && l(e) && c && (a = l(a) ? Math.min(a, e) : e)
                }); return a
            }, nameToX: function (a) { var b = I(this.categories), e = b ? this.categories : this.names, c = a.options.x, p; a.series.requireSorting = !1; l(c) || (c = !1 === this.options.uniqueNames ? a.series.autoIncrement() : r(a.name, e)); -1 === c ? b || (p = e.length) : p = c; this.names[p] = a.name; return p }, updateNames: function () {
                var a = this; 0 < this.names.length && (this.names.length = 0, this.minRange = void 0, f(this.series || [], function (b) {
                    b.xIncrement =
                    null; if (!b.points || b.isDirtyData) b.processData(), b.generatePoints(); f(b.points, function (e, c) { var p; e.options && void 0 === e.options.x && (p = a.nameToX(e), p !== e.x && (e.x = p, b.xData[c] = p)) })
                }))
            }, setAxisTranslation: function (a) {
                var b = this, e = b.max - b.min, c = b.axisPointRange || 0, p, m = 0, d = 0, h = b.linkedParent, r = !!b.categories, w = b.transA, g = b.isXAxis; if (g || r || c) h ? (m = h.minPointOffset, d = h.pointRangePadding) : (p = b.getClosest(), f(b.series, function (a) {
                    var e = r ? 1 : g ? E(a.options.pointRange, p, 0) : b.axisPointRange || 0; a = a.options.pointPlacement;
                    c = Math.max(c, e); b.single || (m = Math.max(m, q(a) ? 0 : e / 2), d = Math.max(d, "on" === a ? 0 : e))
                })), h = b.ordinalSlope && p ? b.ordinalSlope / p : 1, b.minPointOffset = m *= h, b.pointRangePadding = d *= h, b.pointRange = Math.min(c, e), g && (b.closestPointRange = p); a && (b.oldTransA = w); b.translationSlope = b.transA = w = b.len / (e + d || 1); b.transB = b.horiz ? b.left : b.bottom; b.minPixelPadding = w * m
            }, minFromRange: function () { return this.max - this.range }, setTickInterval: function (a) {
                var c = this, p = c.chart, m = c.options, d = c.isLog, r = c.log2lin, w = c.isDatetimeAxis, q = c.isXAxis,
                x = c.isLinked, G = m.maxPadding, k = m.minPadding, v = m.tickInterval, n = m.tickPixelInterval, K = c.categories, t = c.threshold, I = c.softThreshold, u, N, J, A; w || K || x || this.getTickAmount(); J = E(c.userMin, m.min); A = E(c.userMax, m.max); x ? (c.linkedParent = p[c.coll][m.linkedTo], p = c.linkedParent.getExtremes(), c.min = E(p.min, p.dataMin), c.max = E(p.max, p.dataMax), m.type !== c.linkedParent.options.type && h(11, 1)) : (!I && l(t) && (c.dataMin >= t ? (u = t, k = 0) : c.dataMax <= t && (N = t, G = 0)), c.min = E(J, u, c.dataMin), c.max = E(A, N, c.dataMax)); d && (!a && 0 >= Math.min(c.min,
                E(c.dataMin, c.min)) && h(10, 1), c.min = g(r(c.min), 15), c.max = g(r(c.max), 15)); c.range && l(c.max) && (c.userMin = c.min = J = Math.max(c.min, c.minFromRange()), c.userMax = A = c.max, c.range = null); H(c, "foundExtremes"); c.beforePadding && c.beforePadding(); c.adjustForMinRange(); !(K || c.axisPointRange || c.usePercentage || x) && l(c.min) && l(c.max) && (r = c.max - c.min) && (!l(J) && k && (c.min -= r * k), !l(A) && G && (c.max += r * G)); b(m.floor) ? c.min = Math.max(c.min, m.floor) : b(m.softMin) && (c.min = Math.min(c.min, m.softMin)); b(m.ceiling) ? c.max = Math.min(c.max,
                m.ceiling) : b(m.softMax) && (c.max = Math.max(c.max, m.softMax)); I && l(c.dataMin) && (t = t || 0, !l(J) && c.min < t && c.dataMin >= t ? c.min = t : !l(A) && c.max > t && c.dataMax <= t && (c.max = t)); c.tickInterval = c.min === c.max || void 0 === c.min || void 0 === c.max ? 1 : x && !v && n === c.linkedParent.options.tickPixelInterval ? v = c.linkedParent.tickInterval : E(v, this.tickAmount ? (c.max - c.min) / Math.max(this.tickAmount - 1, 1) : void 0, K ? 1 : (c.max - c.min) * n / Math.max(c.len, n)); q && !a && f(c.series, function (a) { a.processData(c.min !== c.oldMin || c.max !== c.oldMax) }); c.setAxisTranslation(!0);
                c.beforeSetTickPositions && c.beforeSetTickPositions(); c.postProcessTickInterval && (c.tickInterval = c.postProcessTickInterval(c.tickInterval)); c.pointRange && !v && (c.tickInterval = Math.max(c.pointRange, c.tickInterval)); a = E(m.minTickInterval, c.isDatetimeAxis && c.closestPointRange); !v && c.tickInterval < a && (c.tickInterval = a); w || d || v || (c.tickInterval = L(c.tickInterval, null, e(c.tickInterval), E(m.allowDecimals, !(.5 < c.tickInterval && 5 > c.tickInterval && 1E3 < c.max && 9999 > c.max)), !!this.tickAmount)); this.tickAmount || (c.tickInterval =
                c.unsquish()); this.setTickPositions()
            }, setTickPositions: function () {
                var a = this.options, b, e = a.tickPositions, c = a.tickPositioner, f = a.startOnTick, m = a.endOnTick, d; this.tickmarkOffset = this.categories && "between" === a.tickmarkPlacement && 1 === this.tickInterval ? .5 : 0; this.minorTickInterval = "auto" === a.minorTickInterval && this.tickInterval ? this.tickInterval / 5 : a.minorTickInterval; this.tickPositions = b = e && e.slice(); !b && (b = this.isDatetimeAxis ? this.getTimeTicks(this.normalizeTimeTickInterval(this.tickInterval, a.units),
                this.min, this.max, a.startOfWeek, this.ordinalPositions, this.closestPointRange, !0) : this.isLog ? this.getLogTickPositions(this.tickInterval, this.min, this.max) : this.getLinearTickPositions(this.tickInterval, this.min, this.max), b.length > this.len && (b = [b[0], b.pop()]), this.tickPositions = b, c && (c = c.apply(this, [this.min, this.max]))) && (this.tickPositions = b = c); this.isLinked || (this.trimTicks(b, f, m), this.min === this.max && l(this.min) && !this.tickAmount && (d = !0, this.min -= .5, this.max += .5), this.single = d, e || c || this.adjustTickAmount())
            },
            trimTicks: function (a, b, e) { var c = a[0], p = a[a.length - 1], f = this.minPointOffset || 0; if (b) this.min = c; else for (; this.min - f > a[0];) a.shift(); if (e) this.max = p; else for (; this.max + f < a[a.length - 1];) a.pop(); 0 === a.length && l(c) && a.push((p + c) / 2) }, alignToOthers: function () { var a = {}, b, c = this.options; !1 !== this.chart.options.chart.alignTicks && !1 !== c.alignTicks && f(this.chart[this.coll], function (c) { var e = c.options, e = [c.horiz ? e.left : e.top, e.width, e.height, e.pane].join(); c.series.length && (a[e] ? b = !0 : a[e] = 1) }); return b }, getTickAmount: function () {
                var a =
                this.options, b = a.tickAmount, e = a.tickPixelInterval; !l(a.tickInterval) && this.len < e && !this.isRadial && !this.isLog && a.startOnTick && a.endOnTick && (b = 2); !b && this.alignToOthers() && (b = Math.ceil(this.len / e) + 1); 4 > b && (this.finalTickAmt = b, b = 5); this.tickAmount = b
            }, adjustTickAmount: function () {
                var a = this.tickInterval, b = this.tickPositions, e = this.tickAmount, c = this.finalTickAmt, f = b && b.length; if (f < e) { for (; b.length < e;) b.push(g(b[b.length - 1] + a)); this.transA *= (f - 1) / (e - 1); this.max = b[b.length - 1] } else f > e && (this.tickInterval *=
                2, this.setTickPositions()); if (l(c)) { for (a = e = b.length; a--;) (3 === c && 1 === a % 2 || 2 >= c && 0 < a && a < e - 1) && b.splice(a, 1); this.finalTickAmt = void 0 }
            }, setScale: function () {
                var a, b; this.oldMin = this.min; this.oldMax = this.max; this.oldAxisLength = this.len; this.setAxisSize(); b = this.len !== this.oldAxisLength; f(this.series, function (b) { if (b.isDirtyData || b.isDirty || b.xAxis.isDirty) a = !0 }); b || a || this.isLinked || this.forceRedraw || this.userMin !== this.oldUserMin || this.userMax !== this.oldUserMax || this.alignToOthers() ? (this.resetStacks &&
                this.resetStacks(), this.forceRedraw = !1, this.getSeriesExtremes(), this.setTickInterval(), this.oldUserMin = this.userMin, this.oldUserMax = this.userMax, this.isDirty || (this.isDirty = b || this.min !== this.oldMin || this.max !== this.oldMax)) : this.cleanStacks && this.cleanStacks()
            }, setExtremes: function (a, b, e, c, m) { var p = this, d = p.chart; e = E(e, !0); f(p.series, function (a) { delete a.kdTree }); m = v(m, { min: a, max: b }); H(p, "setExtremes", m, function () { p.userMin = a; p.userMax = b; p.eventArgs = m; e && d.redraw(c) }) }, zoom: function (a, b) {
                var e = this.dataMin,
                c = this.dataMax, p = this.options, f = Math.min(e, E(p.min, e)), p = Math.max(c, E(p.max, c)); if (a !== this.min || b !== this.max) this.allowZoomOutside || (l(e) && a <= f && (a = f), l(c) && b >= p && (b = p)), this.displayBtn = void 0 !== a || void 0 !== b, this.setExtremes(a, b, !1, void 0, { trigger: "zoom" }); return !0
            }, setAxisSize: function () {
                var a = this.chart, b = this.options, e = b.offsetLeft || 0, c = this.horiz, f = E(b.width, a.plotWidth - e + (b.offsetRight || 0)), m = E(b.height, a.plotHeight), d = E(b.top, a.plotTop), b = E(b.left, a.plotLeft + e), e = /%$/; e.test(m) && (m = Math.round(parseFloat(m) /
                100 * a.plotHeight)); e.test(d) && (d = Math.round(parseFloat(d) / 100 * a.plotHeight + a.plotTop)); this.left = b; this.top = d; this.width = f; this.height = m; this.bottom = a.chartHeight - m - d; this.right = a.chartWidth - f - b; this.len = Math.max(c ? f : m, 0); this.pos = c ? b : d
            }, getExtremes: function () { var a = this.isLog, b = this.lin2log; return { min: a ? g(b(this.min)) : this.min, max: a ? g(b(this.max)) : this.max, dataMin: this.dataMin, dataMax: this.dataMax, userMin: this.userMin, userMax: this.userMax } }, getThreshold: function (a) {
                var b = this.isLog, e = this.lin2log,
                c = b ? e(this.min) : this.min, b = b ? e(this.max) : this.max; null === a ? a = c : c > a ? a = c : b < a && (a = b); return this.translate(a, 0, 1, 0, 1)
            }, autoLabelAlign: function (a) { a = (E(a, 0) - 90 * this.side + 720) % 360; return 15 < a && 165 > a ? "right" : 195 < a && 345 > a ? "left" : "center" }, tickSize: function (a) { var b = this.options, e = b[a + "Length"], c = E(b[a + "Width"], "tick" === a && this.isXAxis ? 1 : 0); if (c && e) return "inside" === b[a + "Position"] && (e = -e), [e, c] }, labelMetrics: function () {
                return this.chart.renderer.fontMetrics(this.options.labels.style && this.options.labels.style.fontSize,
                this.ticks[0] && this.ticks[0].label)
            }, unsquish: function () {
                var a = this.options.labels, b = this.horiz, e = this.tickInterval, c = e, m = this.len / (((this.categories ? 1 : 0) + this.max - this.min) / e), d, h = a.rotation, r = this.labelMetrics(), w, q = Number.MAX_VALUE, g, x = function (a) { a /= m || 1; a = 1 < a ? Math.ceil(a) : 1; return a * e }; b ? (g = !a.staggerLines && !a.step && (l(h) ? [h] : m < E(a.autoRotationLimit, 80) && a.autoRotation)) && f(g, function (a) { var b; if (a === h || a && -90 <= a && 90 >= a) w = x(Math.abs(r.h / Math.sin(t * a))), b = w + Math.abs(a / 360), b < q && (q = b, d = a, c = w) }) :
                a.step || (c = x(r.h)); this.autoRotation = g; this.labelRotation = E(d, h); return c
            }, getSlotWidth: function () { var a = this.chart, b = this.horiz, e = this.options.labels, c = Math.max(this.tickPositions.length - (this.categories ? 0 : 1), 1), f = a.margin[3]; return b && 2 > (e.step || 0) && !e.rotation && (this.staggerLines || 1) * a.plotWidth / c || !b && (f && f - a.spacing[3] || .33 * a.chartWidth) }, renderUnsquish: function () {
                var a = this.chart, b = a.renderer, e = this.tickPositions, c = this.ticks, m = this.options.labels, d = this.horiz, h = this.getSlotWidth(), r = Math.max(1,
                Math.round(h - 2 * (m.padding || 5))), w = {}, g = this.labelMetrics(), l = m.style && m.style.textOverflow, G, v = 0, k, n; q(m.rotation) || (w.rotation = m.rotation || 0); f(e, function (a) { (a = c[a]) && a.labelLength > v && (v = a.labelLength) }); this.maxLabelLength = v; if (this.autoRotation) v > r && v > g.h ? w.rotation = this.labelRotation : this.labelRotation = 0; else if (h && (G = { width: r + "px" }, !l)) for (G.textOverflow = "clip", k = e.length; !d && k--;) if (n = e[k], r = c[n].label) r.styles && "ellipsis" === r.styles.textOverflow ? r.css({ textOverflow: "clip" }) : c[n].labelLength >
                h && r.css({ width: h + "px" }), r.getBBox().height > this.len / e.length - (g.h - g.f) && (r.specCss = { textOverflow: "ellipsis" }); w.rotation && (G = { width: (v > .5 * a.chartHeight ? .33 * a.chartHeight : a.chartHeight) + "px" }, l || (G.textOverflow = "ellipsis")); if (this.labelAlign = m.align || this.autoLabelAlign(this.labelRotation)) w.align = this.labelAlign; f(e, function (a) { var b = (a = c[a]) && a.label; b && (b.attr(w), G && b.css(x(G, b.specCss)), delete b.specCss, a.rotation = w.rotation) }); this.tickRotCorr = b.rotCorr(g.b, this.labelRotation || 0, 0 !== this.side)
            },
            hasData: function () { return this.hasVisibleSeries || l(this.min) && l(this.max) && !!this.tickPositions }, getOffset: function () {
                var a = this, b = a.chart, e = b.renderer, c = a.options, m = a.tickPositions, d = a.ticks, h = a.horiz, r = a.side, w = b.inverted ? [1, 0, 3, 2][r] : r, g, q, x = 0, G, v = 0, k = c.title, n = c.labels, K = 0, t = a.opposite, I = b.axisOffset, b = b.clipOffset, L = [-1, 1, 1, -1][r], u, H = c.className, J = a.axisParent, A = this.tickSize("tick"); g = a.hasData(); a.showAxis = q = g || E(c.showEmpty, !0); a.staggerLines = a.horiz && n.staggerLines; a.axisGroup || (a.gridGroup =
                e.g("grid").attr({ zIndex: c.gridZIndex || 1 }).addClass("highcharts-" + this.coll.toLowerCase() + "-grid " + (H || "")).add(J), a.axisGroup = e.g("axis").attr({ zIndex: c.zIndex || 2 }).addClass("highcharts-" + this.coll.toLowerCase() + " " + (H || "")).add(J), a.labelGroup = e.g("axis-labels").attr({ zIndex: n.zIndex || 7 }).addClass("highcharts-" + a.coll.toLowerCase() + "-labels " + (H || "")).add(J)); if (g || a.isLinked) f(m, function (b) { d[b] ? d[b].addLabel() : d[b] = new N(a, b) }), a.renderUnsquish(), !1 === n.reserveSpace || 0 !== r && 2 !== r && { 1: "left", 3: "right" }[r] !==
                a.labelAlign && "center" !== a.labelAlign || f(m, function (a) { K = Math.max(d[a].getLabelSize(), K) }), a.staggerLines && (K *= a.staggerLines, a.labelOffset = K * (a.opposite ? -1 : 1)); else for (u in d) d[u].destroy(), delete d[u]; k && k.text && !1 !== k.enabled && (a.axisTitle || ((u = k.textAlign) || (u = (h ? { low: "left", middle: "center", high: "right" } : { low: t ? "right" : "left", middle: "center", high: t ? "left" : "right" })[k.align]), a.axisTitle = e.text(k.text, 0, 0, k.useHTML).attr({ zIndex: 7, rotation: k.rotation || 0, align: u }).addClass("highcharts-axis-title").css(k.style).add(a.axisGroup),
                a.axisTitle.isNew = !0), q && (x = a.axisTitle.getBBox()[h ? "height" : "width"], G = k.offset, v = l(G) ? 0 : E(k.margin, h ? 5 : 10)), a.axisTitle[q ? "show" : "hide"](!0)); a.renderLine(); a.offset = L * E(c.offset, I[r]); a.tickRotCorr = a.tickRotCorr || { x: 0, y: 0 }; e = 0 === r ? -a.labelMetrics().h : 2 === r ? a.tickRotCorr.y : 0; v = Math.abs(K) + v; K && (v = v - e + L * (h ? E(n.y, a.tickRotCorr.y + 8 * L) : n.x)); a.axisTitleMargin = E(G, v); I[r] = Math.max(I[r], a.axisTitleMargin + x + L * a.offset, v, g && m.length && A ? A[0] : 0); c = c.offset ? 0 : 2 * Math.floor(a.axisLine.strokeWidth() / 2); b[w] =
                Math.max(b[w], c)
            }, getLinePath: function (a) { var b = this.chart, e = this.opposite, c = this.offset, f = this.horiz, m = this.left + (e ? this.width : 0) + c, c = b.chartHeight - this.bottom - (e ? this.height : 0) + c; e && (a *= -1); return b.renderer.crispLine(["M", f ? this.left : m, f ? c : this.top, "L", f ? b.chartWidth - this.right : m, f ? c : b.chartHeight - this.bottom], a) }, renderLine: function () {
                this.axisLine || (this.axisLine = this.chart.renderer.path().addClass("highcharts-axis-line").add(this.axisGroup), this.axisLine.attr({
                    stroke: this.options.lineColor,
                    "stroke-width": this.options.lineWidth, zIndex: 7
                }))
            }, getTitlePosition: function () { var a = this.horiz, b = this.left, e = this.top, c = this.len, f = this.options.title, m = a ? b : e, d = this.opposite, h = this.offset, r = f.x || 0, w = f.y || 0, g = this.chart.renderer.fontMetrics(f.style && f.style.fontSize, this.axisTitle).f, c = { low: m + (a ? 0 : c), middle: m + c / 2, high: m + (a ? c : 0) }[f.align], b = (a ? e + this.height : b) + (a ? 1 : -1) * (d ? -1 : 1) * this.axisTitleMargin + (2 === this.side ? g : 0); return { x: a ? c + r : b + (d ? this.width : 0) + h + r, y: a ? b + w - (d ? this.height : 0) + h : c + w } }, render: function () {
                var a =
                this, e = a.chart, c = e.renderer, m = a.options, d = a.isLog, h = a.lin2log, r = a.isLinked, w = a.tickPositions, g = a.axisTitle, q = a.ticks, x = a.minorTicks, l = a.alternateBands, v = m.stackLabels, k = m.alternateGridColor, n = a.tickmarkOffset, K = a.axisLine, E = e.hasRendered && b(a.oldMin), t = a.showAxis, I = A(c.globalAnimation), L, u; a.labelEdge.length = 0; a.overlap = !1; f([q, x, l], function (a) { for (var b in a) a[b].isActive = !1 }); if (a.hasData() || r) a.minorTickInterval && !a.categories && f(a.getMinorTickPositions(), function (b) {
                    x[b] || (x[b] = new N(a, b, "minor"));
                    E && x[b].isNew && x[b].render(null, !0); x[b].render(null, !1, 1)
                }), w.length && (f(w, function (b, e) { if (!r || b >= a.min && b <= a.max) q[b] || (q[b] = new N(a, b)), E && q[b].isNew && q[b].render(e, !0, .1), q[b].render(e) }), n && (0 === a.min || a.single) && (q[-1] || (q[-1] = new N(a, -1, null, !0)), q[-1].render(-1))), k && f(w, function (b, c) { u = void 0 !== w[c + 1] ? w[c + 1] + n : a.max - n; 0 === c % 2 && b < a.max && u <= a.max + (e.polar ? -n : n) && (l[b] || (l[b] = new J(a)), L = b + n, l[b].options = { from: d ? h(L) : L, to: d ? h(u) : u, color: k }, l[b].render(), l[b].isActive = !0) }), a._addedPlotLB ||
                (f((m.plotLines || []).concat(m.plotBands || []), function (b) { a.addPlotBandOrLine(b) }), a._addedPlotLB = !0); f([q, x, l], function (a) { var b, c, f = [], m = I.duration; for (b in a) a[b].isActive || (a[b].render(b, !1, 0), a[b].isActive = !1, f.push(b)); G(function () { for (c = f.length; c--;) a[f[c]] && !a[f[c]].isActive && (a[f[c]].destroy(), delete a[f[c]]) }, a !== l && e.hasRendered && m ? m : 0) }); K && (K[K.isPlaced ? "animate" : "attr"]({ d: this.getLinePath(K.strokeWidth()) }), K.isPlaced = !0, K[t ? "show" : "hide"](!0)); g && t && (g[g.isNew ? "attr" : "animate"](a.getTitlePosition()),
                g.isNew = !1); v && v.enabled && a.renderStackTotals(); a.isDirty = !1
            }, redraw: function () { this.visible && (this.render(), f(this.plotLinesAndBands, function (a) { a.render() })); f(this.series, function (a) { a.isDirty = !0 }) }, keepProps: "extKey hcEvents names series userMax userMin".split(" "), destroy: function (a) {
                var b = this, e = b.stacks, c, m = b.plotLinesAndBands, d; a || w(b); for (c in e) n(e[c]), e[c] = null; f([b.ticks, b.minorTicks, b.alternateBands], function (a) { n(a) }); if (m) for (a = m.length; a--;) m[a].destroy(); f("stackTotalGroup axisLine axisTitle axisGroup gridGroup labelGroup cross".split(" "),
                function (a) { b[a] && (b[a] = b[a].destroy()) }); for (d in b) b.hasOwnProperty(d) && -1 === r(d, b.keepProps) && delete b[d]
            }, drawCrosshair: function (a, b) {
                var e, c = this.crosshair, f = E(c.snap, !0), m, p = this.cross; a || (a = this.cross && this.cross.e); this.crosshair && !1 !== (l(b) || !f) ? (f ? l(b) && (m = this.isXAxis ? b.plotX : this.len - b.plotY) : m = a && (this.horiz ? a.chartX - this.pos : this.len - a.chartY + this.pos), l(m) && (e = this.getPlotLinePath(b && (this.isXAxis ? b.x : E(b.stackY, b.y)), null, null, null, m) || null), l(e) ? (b = this.categories && !this.isRadial,
                p || (this.cross = p = this.chart.renderer.path().addClass("highcharts-crosshair highcharts-crosshair-" + (b ? "category " : "thin ") + c.className).attr({ zIndex: E(c.zIndex, 2) }).add(), p.attr({ stroke: c.color || (b ? d("#ccd6eb").setOpacity(.25).get() : "#cccccc"), "stroke-width": E(c.width, 1) }), c.dashStyle && p.attr({ dashstyle: c.dashStyle })), p.show().attr({ d: e }), b && !c.width && p.attr({ "stroke-width": this.transA }), this.cross.e = a) : this.hideCrosshair()) : this.hideCrosshair()
            }, hideCrosshair: function () { this.cross && this.cross.hide() }
        };
        v(a.Axis.prototype, k)
    })(M); (function (a) {
        var C = a.Axis, A = a.Date, D = a.dateFormat, F = a.defaultOptions, k = a.defined, d = a.each, g = a.extend, u = a.getMagnitude, l = a.getTZOffset, t = a.normalizeTickInterval, n = a.pick, f = a.timeUnits; C.prototype.getTimeTicks = function (a, v, t, c) {
            var e = [], m = {}, r = F.global.useUTC, h, b = new A(v - l(v)), q = A.hcMakeTime, x = a.unitRange, L = a.count, E; if (k(v)) {
                b[A.hcSetMilliseconds](x >= f.second ? 0 : L * Math.floor(b.getMilliseconds() / L)); if (x >= f.second) b[A.hcSetSeconds](x >= f.minute ? 0 : L * Math.floor(b.getSeconds() /
                L)); if (x >= f.minute) b[A.hcSetMinutes](x >= f.hour ? 0 : L * Math.floor(b[A.hcGetMinutes]() / L)); if (x >= f.hour) b[A.hcSetHours](x >= f.day ? 0 : L * Math.floor(b[A.hcGetHours]() / L)); if (x >= f.day) b[A.hcSetDate](x >= f.month ? 1 : L * Math.floor(b[A.hcGetDate]() / L)); x >= f.month && (b[A.hcSetMonth](x >= f.year ? 0 : L * Math.floor(b[A.hcGetMonth]() / L)), h = b[A.hcGetFullYear]()); if (x >= f.year) b[A.hcSetFullYear](h - h % L); if (x === f.week) b[A.hcSetDate](b[A.hcGetDate]() - b[A.hcGetDay]() + n(c, 1)); h = b[A.hcGetFullYear](); c = b[A.hcGetMonth](); var u = b[A.hcGetDate](),
                w = b[A.hcGetHours](); if (A.hcTimezoneOffset || A.hcGetTimezoneOffset) E = (!r || !!A.hcGetTimezoneOffset) && (t - v > 4 * f.month || l(v) !== l(t)), b = b.getTime(), b = new A(b + l(b)); r = b.getTime(); for (v = 1; r < t;) e.push(r), r = x === f.year ? q(h + v * L, 0) : x === f.month ? q(h, c + v * L) : !E || x !== f.day && x !== f.week ? E && x === f.hour ? q(h, c, u, w + v * L) : r + x * L : q(h, c, u + v * L * (x === f.day ? 1 : 7)), v++; e.push(r); x <= f.hour && d(e, function (a) { "000000000" === D("%H%M%S%L", a) && (m[a] = "day") })
            } e.info = g(a, { higherRanks: m, totalRange: x * L }); return e
        }; C.prototype.normalizeTimeTickInterval =
        function (a, d) { var h = d || [["millisecond", [1, 2, 5, 10, 20, 25, 50, 100, 200, 500]], ["second", [1, 2, 5, 10, 15, 30]], ["minute", [1, 2, 5, 10, 15, 30]], ["hour", [1, 2, 3, 4, 6, 8, 12]], ["day", [1, 2]], ["week", [1, 2]], ["month", [1, 2, 3, 4, 6]], ["year", null]]; d = h[h.length - 1]; var c = f[d[0]], e = d[1], m; for (m = 0; m < h.length && !(d = h[m], c = f[d[0]], e = d[1], h[m + 1] && a <= (c * e[e.length - 1] + f[h[m + 1][0]]) / 2) ; m++); c === f.year && a < 5 * c && (e = [1, 2, 5]); a = t(a / c, e, "year" === d[0] ? Math.max(u(a / c), 1) : 1); return { unitRange: c, count: a, unitName: d[0] } }
    })(M); (function (a) {
        var C = a.Axis,
        A = a.getMagnitude, D = a.map, F = a.normalizeTickInterval, k = a.pick; C.prototype.getLogTickPositions = function (a, g, u, l) {
            var d = this.options, n = this.len, f = this.lin2log, h = this.log2lin, v = []; l || (this._minorAutoInterval = null); if (.5 <= a) a = Math.round(a), v = this.getLinearTickPositions(a, g, u); else if (.08 <= a) for (var n = Math.floor(g), H, c, e, m, r, d = .3 < a ? [1, 2, 4] : .15 < a ? [1, 2, 4, 6, 8] : [1, 2, 3, 4, 5, 6, 7, 8, 9]; n < u + 1 && !r; n++) for (c = d.length, H = 0; H < c && !r; H++) e = h(f(n) * d[H]), e > g && (!l || m <= u) && void 0 !== m && v.push(m), m > u && (r = !0), m = e; else g = f(g), u =
            f(u), a = d[l ? "minorTickInterval" : "tickInterval"], a = k("auto" === a ? null : a, this._minorAutoInterval, d.tickPixelInterval / (l ? 5 : 1) * (u - g) / ((l ? n / this.tickPositions.length : n) || 1)), a = F(a, null, A(a)), v = D(this.getLinearTickPositions(a, g, u), h), l || (this._minorAutoInterval = a / 5); l || (this.tickInterval = a); return v
        }; C.prototype.log2lin = function (a) { return Math.log(a) / Math.LN10 }; C.prototype.lin2log = function (a) { return Math.pow(10, a) }
    })(M); (function (a) {
        var C = a.dateFormat, A = a.each, D = a.extend, F = a.format, k = a.isNumber, d = a.map, g =
        a.merge, u = a.pick, l = a.splat, t = a.stop, n = a.syncTimeout, f = a.timeUnits; a.Tooltip = function () { this.init.apply(this, arguments) }; a.Tooltip.prototype = {
            init: function (a, f) { this.chart = a; this.options = f; this.crosshairs = []; this.now = { x: 0, y: 0 }; this.isHidden = !0; this.split = f.split && !a.inverted; this.shared = f.shared || this.split }, cleanSplit: function (a) { A(this.chart.series, function (f) { var d = f && f.tt; d && (!d.isActive || a ? f.tt = d.destroy() : d.isActive = !1) }) }, getLabel: function () {
                var a = this.chart.renderer, f = this.options; this.label ||
                (this.split ? this.label = a.g("tooltip") : (this.label = a.label("", 0, 0, f.shape || "callout", null, null, f.useHTML, null, "tooltip").attr({ padding: f.padding, r: f.borderRadius }), this.label.attr({ fill: f.backgroundColor, "stroke-width": f.borderWidth }).css(f.style).shadow(f.shadow)), this.label.attr({ zIndex: 8 }).add()); return this.label
            }, update: function (a) { this.destroy(); this.init(this.chart, g(!0, this.options, a)) }, destroy: function () {
                this.label && (this.label = this.label.destroy()); this.split && this.tt && (this.cleanSplit(this.chart,
                !0), this.tt = this.tt.destroy()); clearTimeout(this.hideTimer); clearTimeout(this.tooltipTimeout)
            }, move: function (a, f, d, c) { var e = this, m = e.now, r = !1 !== e.options.animation && !e.isHidden && (1 < Math.abs(a - m.x) || 1 < Math.abs(f - m.y)), h = e.followPointer || 1 < e.len; D(m, { x: r ? (2 * m.x + a) / 3 : a, y: r ? (m.y + f) / 2 : f, anchorX: h ? void 0 : r ? (2 * m.anchorX + d) / 3 : d, anchorY: h ? void 0 : r ? (m.anchorY + c) / 2 : c }); e.getLabel().attr(m); r && (clearTimeout(this.tooltipTimeout), this.tooltipTimeout = setTimeout(function () { e && e.move(a, f, d, c) }, 32)) }, hide: function (a) {
                var f =
                this; clearTimeout(this.hideTimer); a = u(a, this.options.hideDelay, 500); this.isHidden || (this.hideTimer = n(function () { f.getLabel()[a ? "fadeOut" : "hide"](); f.isHidden = !0 }, a))
            }, getAnchor: function (a, f) {
                var h, c = this.chart, e = c.inverted, m = c.plotTop, r = c.plotLeft, g = 0, b = 0, q, x; a = l(a); h = a[0].tooltipPos; this.followPointer && f && (void 0 === f.chartX && (f = c.pointer.normalize(f)), h = [f.chartX - c.plotLeft, f.chartY - m]); h || (A(a, function (a) {
                    q = a.series.yAxis; x = a.series.xAxis; g += a.plotX + (!e && x ? x.left - r : 0); b += (a.plotLow ? (a.plotLow + a.plotHigh) /
                    2 : a.plotY) + (!e && q ? q.top - m : 0)
                }), g /= a.length, b /= a.length, h = [e ? c.plotWidth - b : g, this.shared && !e && 1 < a.length && f ? f.chartY - m : e ? c.plotHeight - g : b]); return d(h, Math.round)
            }, getPosition: function (a, f, d) {
                var c = this.chart, e = this.distance, m = {}, r = d.h || 0, h, b = ["y", c.chartHeight, f, d.plotY + c.plotTop, c.plotTop, c.plotTop + c.plotHeight], g = ["x", c.chartWidth, a, d.plotX + c.plotLeft, c.plotLeft, c.plotLeft + c.plotWidth], x = !this.followPointer && u(d.ttBelow, !c.inverted === !!d.negative), l = function (a, b, c, f, d, h) {
                    var p = c < f - e, w = f + e + c < b, g =
                    f - e - c; f += e; if (x && w) m[a] = f; else if (!x && p) m[a] = g; else if (p) m[a] = Math.min(h - c, 0 > g - r ? g : g - r); else if (w) m[a] = Math.max(d, f + r + c > b ? f : f + r); else return !1
                }, k = function (a, b, c, f) { var d; f < e || f > b - e ? d = !1 : m[a] = f < c / 2 ? 1 : f > b - c / 2 ? b - c - 2 : f - c / 2; return d }, n = function (a) { var c = b; b = g; g = c; h = a }, w = function () { !1 !== l.apply(0, b) ? !1 !== k.apply(0, g) || h || (n(!0), w()) : h ? m.x = m.y = 0 : (n(!0), w()) }; (c.inverted || 1 < this.len) && n(); w(); return m
            }, defaultFormatter: function (a) {
                var f = this.points || l(this), d; d = [a.tooltipFooterHeaderFormatter(f[0])]; d = d.concat(a.bodyFormatter(f));
                d.push(a.tooltipFooterHeaderFormatter(f[0], !0)); return d
            }, refresh: function (a, f) {
                var d = this.chart, c, e = this.options, m, r, h = {}, b = []; c = e.formatter || this.defaultFormatter; var h = d.hoverPoints, g = this.shared; clearTimeout(this.hideTimer); this.followPointer = l(a)[0].series.tooltipOptions.followPointer; r = this.getAnchor(a, f); f = r[0]; m = r[1]; !g || a.series && a.series.noSharedTooltip ? h = a.getLabelConfig() : (d.hoverPoints = a, h && A(h, function (a) { a.setState() }), A(a, function (a) { a.setState("hover"); b.push(a.getLabelConfig()) }),
                h = { x: a[0].category, y: a[0].y }, h.points = b, this.len = b.length, a = a[0]); h = c.call(h, this); g = a.series; this.distance = u(g.tooltipOptions.distance, 16); !1 === h ? this.hide() : (c = this.getLabel(), this.isHidden && (t(c), c.attr({ opacity: 1 }).show()), this.split ? this.renderSplit(h, d.hoverPoints) : (c.attr({ text: h && h.join ? h.join("") : h }), c.removeClass(/highcharts-color-[\d]+/g).addClass("highcharts-color-" + u(a.colorIndex, g.colorIndex)), c.attr({ stroke: e.borderColor || a.color || g.color || "#666666" }), this.updatePosition({
                    plotX: f, plotY: m,
                    negative: a.negative, ttBelow: a.ttBelow, h: r[2] || 0
                })), this.isHidden = !1)
            }, renderSplit: function (f, d) {
                var h = this, c = [], e = this.chart, m = e.renderer, r = !0, g = this.options, b, q = this.getLabel(); A(f.slice(0, f.length - 1), function (a, f) {
                    f = d[f - 1] || { isHeader: !0, plotX: d[0].plotX }; var x = f.series || h, l = x.tt, w = f.series || {}, k = "highcharts-color-" + u(f.colorIndex, w.colorIndex, "none"); l || (x.tt = l = m.label(null, null, null, "callout").addClass("highcharts-tooltip-box " + k).attr({
                        padding: g.padding, r: g.borderRadius, fill: g.backgroundColor,
                        stroke: f.color || w.color || "#333333", "stroke-width": g.borderWidth
                    }).add(q)); l.isActive = !0; l.attr({ text: a }); l.css(g.style); a = l.getBBox(); w = a.width + l.strokeWidth(); f.isHeader ? (b = a.height, w = Math.max(0, Math.min(f.plotX + e.plotLeft - w / 2, e.chartWidth - w))) : w = f.plotX + e.plotLeft - u(g.distance, 16) - w; 0 > w && (r = !1); a = (f.series && f.series.yAxis && f.series.yAxis.pos) + (f.plotY || 0); a -= e.plotTop; c.push({ target: f.isHeader ? e.plotHeight + b : a, rank: f.isHeader ? 1 : 0, size: x.tt.getBBox().height + 1, point: f, x: w, tt: l })
                }); this.cleanSplit();
                a.distribute(c, e.plotHeight + b); A(c, function (a) { var b = a.point; a.tt.attr({ visibility: void 0 === a.pos ? "hidden" : "inherit", x: r || b.isHeader ? a.x : b.plotX + e.plotLeft + u(g.distance, 16), y: a.pos + e.plotTop, anchorX: b.plotX + e.plotLeft, anchorY: b.isHeader ? a.pos + e.plotTop - 15 : b.plotY + e.plotTop }) })
            }, updatePosition: function (a) { var f = this.chart, d = this.getLabel(), d = (this.options.positioner || this.getPosition).call(this, d.width, d.height, a); this.move(Math.round(d.x), Math.round(d.y || 0), a.plotX + f.plotLeft, a.plotY + f.plotTop) },
            getXDateFormat: function (a, d, g) { var c; d = d.dateTimeLabelFormats; var e = g && g.closestPointRange, m, r = { millisecond: 15, second: 12, minute: 9, hour: 6, day: 3 }, h, b = "millisecond"; if (e) { h = C("%m-%d %H:%M:%S.%L", a.x); for (m in f) { if (e === f.week && +C("%w", a.x) === g.options.startOfWeek && "00:00:00.000" === h.substr(6)) { m = "week"; break } if (f[m] > e) { m = b; break } if (r[m] && h.substr(r[m]) !== "01-01 00:00:00.000".substr(r[m])) break; "week" !== m && (b = m) } m && (c = d[m]) } else c = d.day; return c || d.year }, tooltipFooterHeaderFormatter: function (a, f) {
                var d =
                f ? "footer" : "header"; f = a.series; var c = f.tooltipOptions, e = c.xDateFormat, m = f.xAxis, r = m && "datetime" === m.options.type && k(a.key), d = c[d + "Format"]; r && !e && (e = this.getXDateFormat(a, c, m)); r && e && (d = d.replace("{point.key}", "{point.key:" + e + "}")); return F(d, { point: a, series: f })
            }, bodyFormatter: function (a) { return d(a, function (a) { var f = a.series.tooltipOptions; return (f.pointFormatter || a.point.tooltipFormatter).call(a.point, f.pointFormat) }) }
        }
    })(M); (function (a) {
        var C = a.addEvent, A = a.attr, D = a.charts, F = a.color, k = a.css, d =
        a.defined, g = a.doc, u = a.each, l = a.extend, t = a.fireEvent, n = a.offset, f = a.pick, h = a.removeEvent, v = a.splat, H = a.Tooltip, c = a.win; a.Pointer = function (a, c) { this.init(a, c) }; a.Pointer.prototype = {
            init: function (a, c) { this.options = c; this.chart = a; this.runChartClick = c.chart.events && !!c.chart.events.click; this.pinchDown = []; this.lastValidTouch = {}; H && c.tooltip.enabled && (a.tooltip = new H(a, c.tooltip), this.followTouchMove = f(c.tooltip.followTouchMove, !0)); this.setDOMEvents() }, zoomOption: function (a) {
                var c = this.chart, e = c.options.chart,
                d = e.zoomType || "", c = c.inverted; /touch/.test(a.type) && (d = f(e.pinchType, d)); this.zoomX = a = /x/.test(d); this.zoomY = d = /y/.test(d); this.zoomHor = a && !c || d && c; this.zoomVert = d && !c || a && c; this.hasZoom = a || d
            }, normalize: function (a, f) {
                var e, m; a = a || c.event; a.target || (a.target = a.srcElement); m = a.touches ? a.touches.length ? a.touches.item(0) : a.changedTouches[0] : a; f || (this.chartPosition = f = n(this.chart.container)); void 0 === m.pageX ? (e = Math.max(a.x, a.clientX - f.left), f = a.y) : (e = m.pageX - f.left, f = m.pageY - f.top); return l(a, {
                    chartX: Math.round(e),
                    chartY: Math.round(f)
                })
            }, getCoordinates: function (a) { var c = { xAxis: [], yAxis: [] }; u(this.chart.axes, function (e) { c[e.isXAxis ? "xAxis" : "yAxis"].push({ axis: e, value: e.toValue(a[e.horiz ? "chartX" : "chartY"]) }) }); return c }, runPointActions: function (c) {
                var e = this.chart, d = e.series, h = e.tooltip, b = h ? h.shared : !1, q = !0, l = e.hoverPoint, k = e.hoverSeries, n, t, w, K = [], G; if (!b && !k) for (n = 0; n < d.length; n++) if (d[n].directTouch || !d[n].options.stickyTracking) d = []; k && (b ? k.noSharedTooltip : k.directTouch) && l ? K = [l] : (b || !k || k.options.stickyTracking ||
                (d = [k]), u(d, function (a) { t = a.noSharedTooltip && b; w = !b && a.directTouch; a.visible && !t && !w && f(a.options.enableMouseTracking, !0) && (G = a.searchPoint(c, !t && 1 === a.kdDimensions)) && G.series && K.push(G) }), K.sort(function (a, c) { var e = a.distX - c.distX, f = a.dist - c.dist, m = c.series.group.zIndex - a.series.group.zIndex; return 0 !== e && b ? e : 0 !== f ? f : 0 !== m ? m : a.series.index > c.series.index ? -1 : 1 })); if (b) for (n = K.length; n--;) (K[n].x !== K[0].x || K[n].series.noSharedTooltip) && K.splice(n, 1); if (K[0] && (K[0] !== this.prevKDPoint || h && h.isHidden)) {
                    if (b &&
                    !K[0].series.noSharedTooltip) { for (n = 0; n < K.length; n++) K[n].onMouseOver(c, K[n] !== (k && k.directTouch && l || K[0])); K.length && h && h.refresh(K.sort(function (a, b) { return a.series.index - b.series.index }), c) } else if (h && h.refresh(K[0], c), !k || !k.directTouch) K[0].onMouseOver(c); this.prevKDPoint = K[0]; q = !1
                } q && (d = k && k.tooltipOptions.followPointer, h && d && !h.isHidden && (d = h.getAnchor([{}], c), h.updatePosition({ plotX: d[0], plotY: d[1] }))); this.unDocMouseMove || (this.unDocMouseMove = C(g, "mousemove", function (b) { if (D[a.hoverChartIndex]) D[a.hoverChartIndex].pointer.onDocumentMouseMove(b) }));
                u(b ? K : [f(l, K[0])], function (a) { u(e.axes, function (b) { (!a || a.series && a.series[b.coll] === b) && b.drawCrosshair(c, a) }) })
            }, reset: function (a, c) {
                var e = this.chart, f = e.hoverSeries, b = e.hoverPoint, m = e.hoverPoints, d = e.tooltip, h = d && d.shared ? m : b; a && h && u(v(h), function (b) { b.series.isCartesian && void 0 === b.plotX && (a = !1) }); if (a) d && h && (d.refresh(h), b && (b.setState(b.state, !0), u(e.axes, function (a) { a.crosshair && a.drawCrosshair(null, b) }))); else {
                    if (b) b.onMouseOut(); m && u(m, function (a) { a.setState() }); if (f) f.onMouseOut(); d && d.hide(c);
                    this.unDocMouseMove && (this.unDocMouseMove = this.unDocMouseMove()); u(e.axes, function (a) { a.hideCrosshair() }); this.hoverX = this.prevKDPoint = e.hoverPoints = e.hoverPoint = null
                }
            }, scaleGroups: function (a, c) { var e = this.chart, f; u(e.series, function (b) { f = a || b.getPlotBox(); b.xAxis && b.xAxis.zoomEnabled && b.group && (b.group.attr(f), b.markerGroup && (b.markerGroup.attr(f), b.markerGroup.clip(c ? e.clipRect : null)), b.dataLabelsGroup && b.dataLabelsGroup.attr(f)) }); e.clipRect.attr(c || e.clipBox) }, dragStart: function (a) {
                var c = this.chart;
                c.mouseIsDown = a.type; c.cancelClick = !1; c.mouseDownX = this.mouseDownX = a.chartX; c.mouseDownY = this.mouseDownY = a.chartY
            }, drag: function (a) {
                var c = this.chart, e = c.options.chart, f = a.chartX, b = a.chartY, d = this.zoomHor, h = this.zoomVert, g = c.plotLeft, l = c.plotTop, k = c.plotWidth, w = c.plotHeight, n, G = this.selectionMarker, t = this.mouseDownX, p = this.mouseDownY, y = e.panKey && a[e.panKey + "Key"]; G && G.touch || (f < g ? f = g : f > g + k && (f = g + k), b < l ? b = l : b > l + w && (b = l + w), this.hasDragged = Math.sqrt(Math.pow(t - f, 2) + Math.pow(p - b, 2)), 10 < this.hasDragged &&
                (n = c.isInsidePlot(t - g, p - l), c.hasCartesianSeries && (this.zoomX || this.zoomY) && n && !y && !G && (this.selectionMarker = G = c.renderer.rect(g, l, d ? 1 : k, h ? 1 : w, 0).attr({ fill: e.selectionMarkerFill || F("#335cad").setOpacity(.25).get(), "class": "highcharts-selection-marker", zIndex: 7 }).add()), G && d && (f -= t, G.attr({ width: Math.abs(f), x: (0 < f ? 0 : f) + t })), G && h && (f = b - p, G.attr({ height: Math.abs(f), y: (0 < f ? 0 : f) + p })), n && !G && e.panning && c.pan(a, e.panning)))
            }, drop: function (a) {
                var c = this, e = this.chart, f = this.hasPinched; if (this.selectionMarker) {
                    var b =
                    { originalEvent: a, xAxis: [], yAxis: [] }, h = this.selectionMarker, g = h.attr ? h.attr("x") : h.x, n = h.attr ? h.attr("y") : h.y, E = h.attr ? h.attr("width") : h.width, v = h.attr ? h.attr("height") : h.height, w; if (this.hasDragged || f) u(e.axes, function (e) { if (e.zoomEnabled && d(e.min) && (f || c[{ xAxis: "zoomX", yAxis: "zoomY" }[e.coll]])) { var m = e.horiz, h = "touchend" === a.type ? e.minPixelPadding : 0, p = e.toValue((m ? g : n) + h), m = e.toValue((m ? g + E : n + v) - h); b[e.coll].push({ axis: e, min: Math.min(p, m), max: Math.max(p, m) }); w = !0 } }), w && t(e, "selection", b, function (a) {
                        e.zoom(l(a,
                        f ? { animation: !1 } : null))
                    }); this.selectionMarker = this.selectionMarker.destroy(); f && this.scaleGroups()
                } e && (k(e.container, { cursor: e._cursor }), e.cancelClick = 10 < this.hasDragged, e.mouseIsDown = this.hasDragged = this.hasPinched = !1, this.pinchDown = [])
            }, onContainerMouseDown: function (a) { a = this.normalize(a); this.zoomOption(a); a.preventDefault && a.preventDefault(); this.dragStart(a) }, onDocumentMouseUp: function (c) { D[a.hoverChartIndex] && D[a.hoverChartIndex].pointer.drop(c) }, onDocumentMouseMove: function (a) {
                var c = this.chart,
                e = this.chartPosition; a = this.normalize(a, e); !e || this.inClass(a.target, "highcharts-tracker") || c.isInsidePlot(a.chartX - c.plotLeft, a.chartY - c.plotTop) || this.reset()
            }, onContainerMouseLeave: function (c) { var e = D[a.hoverChartIndex]; e && (c.relatedTarget || c.toElement) && (e.pointer.reset(), e.pointer.chartPosition = null) }, onContainerMouseMove: function (c) {
                var e = this.chart; d(a.hoverChartIndex) && D[a.hoverChartIndex] && D[a.hoverChartIndex].mouseIsDown || (a.hoverChartIndex = e.index); c = this.normalize(c); c.returnValue = !1;
                "mousedown" === e.mouseIsDown && this.drag(c); !this.inClass(c.target, "highcharts-tracker") && !e.isInsidePlot(c.chartX - e.plotLeft, c.chartY - e.plotTop) || e.openMenu || this.runPointActions(c)
            }, inClass: function (a, c) { for (var e; a;) { if (e = A(a, "class")) { if (-1 !== e.indexOf(c)) return !0; if (-1 !== e.indexOf("highcharts-container")) return !1 } a = a.parentNode } }, onTrackerMouseOut: function (a) {
                var c = this.chart.hoverSeries; a = a.relatedTarget || a.toElement; if (!(!c || !a || c.options.stickyTracking || this.inClass(a, "highcharts-tooltip") ||
                this.inClass(a, "highcharts-series-" + c.index) && this.inClass(a, "highcharts-tracker"))) c.onMouseOut()
            }, onContainerClick: function (a) { var c = this.chart, e = c.hoverPoint, f = c.plotLeft, b = c.plotTop; a = this.normalize(a); c.cancelClick || (e && this.inClass(a.target, "highcharts-tracker") ? (t(e.series, "click", l(a, { point: e })), c.hoverPoint && e.firePointEvent("click", a)) : (l(a, this.getCoordinates(a)), c.isInsidePlot(a.chartX - f, a.chartY - b) && t(c, "click", a))) }, setDOMEvents: function () {
                var c = this, f = c.chart.container; f.onmousedown =
                function (a) { c.onContainerMouseDown(a) }; f.onmousemove = function (a) { c.onContainerMouseMove(a) }; f.onclick = function (a) { c.onContainerClick(a) }; C(f, "mouseleave", c.onContainerMouseLeave); 1 === a.chartCount && C(g, "mouseup", c.onDocumentMouseUp); a.hasTouch && (f.ontouchstart = function (a) { c.onContainerTouchStart(a) }, f.ontouchmove = function (a) { c.onContainerTouchMove(a) }, 1 === a.chartCount && C(g, "touchend", c.onDocumentTouchEnd))
            }, destroy: function () {
                var c; h(this.chart.container, "mouseleave", this.onContainerMouseLeave); a.chartCount ||
                (h(g, "mouseup", this.onDocumentMouseUp), h(g, "touchend", this.onDocumentTouchEnd)); clearInterval(this.tooltipTimeout); for (c in this) this[c] = null
            }
        }
    })(M); (function (a) {
        var C = a.charts, A = a.each, D = a.extend, F = a.map, k = a.noop, d = a.pick; D(a.Pointer.prototype, {
            pinchTranslate: function (a, d, l, k, n, f) { this.zoomHor && this.pinchTranslateDirection(!0, a, d, l, k, n, f); this.zoomVert && this.pinchTranslateDirection(!1, a, d, l, k, n, f) }, pinchTranslateDirection: function (a, d, l, k, n, f, h, v) {
                var g = this.chart, c = a ? "x" : "y", e = a ? "X" : "Y", m = "chart" +
                e, r = a ? "width" : "height", t = g["plot" + (a ? "Left" : "Top")], b, q, x = v || 1, u = g.inverted, E = g.bounds[a ? "h" : "v"], J = 1 === d.length, w = d[0][m], K = l[0][m], G = !J && d[1][m], N = !J && l[1][m], p; l = function () { !J && 20 < Math.abs(w - G) && (x = v || Math.abs(K - N) / Math.abs(w - G)); q = (t - K) / x + w; b = g["plot" + (a ? "Width" : "Height")] / x }; l(); d = q; d < E.min ? (d = E.min, p = !0) : d + b > E.max && (d = E.max - b, p = !0); p ? (K -= .8 * (K - h[c][0]), J || (N -= .8 * (N - h[c][1])), l()) : h[c] = [K, N]; u || (f[c] = q - t, f[r] = b); f = u ? 1 / x : x; n[r] = b; n[c] = d; k[u ? a ? "scaleY" : "scaleX" : "scale" + e] = x; k["translate" + e] = f *
                t + (K - f * w)
            }, pinch: function (a) {
                var g = this, l = g.chart, t = g.pinchDown, n = a.touches, f = n.length, h = g.lastValidTouch, v = g.hasZoom, H = g.selectionMarker, c = {}, e = 1 === f && (g.inClass(a.target, "highcharts-tracker") && l.runTrackerClick || g.runChartClick), m = {}; 1 < f && (g.initiated = !0); v && g.initiated && !e && a.preventDefault(); F(n, function (a) { return g.normalize(a) }); "touchstart" === a.type ? (A(n, function (a, c) { t[c] = { chartX: a.chartX, chartY: a.chartY } }), h.x = [t[0].chartX, t[1] && t[1].chartX], h.y = [t[0].chartY, t[1] && t[1].chartY], A(l.axes, function (a) {
                    if (a.zoomEnabled) {
                        var c =
                        l.bounds[a.horiz ? "h" : "v"], b = a.minPixelPadding, e = a.toPixels(d(a.options.min, a.dataMin)), f = a.toPixels(d(a.options.max, a.dataMax)), m = Math.max(e, f); c.min = Math.min(a.pos, Math.min(e, f) - b); c.max = Math.max(a.pos + a.len, m + b)
                    }
                }), g.res = !0) : g.followTouchMove && 1 === f ? this.runPointActions(g.normalize(a)) : t.length && (H || (g.selectionMarker = H = D({ destroy: k, touch: !0 }, l.plotBox)), g.pinchTranslate(t, n, c, H, m, h), g.hasPinched = v, g.scaleGroups(c, m), g.res && (g.res = !1, this.reset(!1, 0)))
            }, touch: function (g, k) {
                var l = this.chart, t, n;
                a.hoverChartIndex = l.index; 1 === g.touches.length ? (g = this.normalize(g), (n = l.isInsidePlot(g.chartX - l.plotLeft, g.chartY - l.plotTop)) && !l.openMenu ? (k && this.runPointActions(g), "touchmove" === g.type && (k = this.pinchDown, t = k[0] ? 4 <= Math.sqrt(Math.pow(k[0].chartX - g.chartX, 2) + Math.pow(k[0].chartY - g.chartY, 2)) : !1), d(t, !0) && this.pinch(g)) : k && this.reset()) : 2 === g.touches.length && this.pinch(g)
            }, onContainerTouchStart: function (a) { this.zoomOption(a); this.touch(a, !0) }, onContainerTouchMove: function (a) { this.touch(a) }, onDocumentTouchEnd: function (d) {
                C[a.hoverChartIndex] &&
                C[a.hoverChartIndex].pointer.drop(d)
            }
        })
    })(M); (function (a) {
        var C = a.addEvent, A = a.charts, D = a.css, F = a.doc, k = a.extend, d = a.noop, g = a.Pointer, u = a.removeEvent, l = a.win, t = a.wrap; if (l.PointerEvent || l.MSPointerEvent) {
            var n = {}, f = !!l.PointerEvent, h = function () { var a, c = []; c.item = function (a) { return this[a] }; for (a in n) n.hasOwnProperty(a) && c.push({ pageX: n[a].pageX, pageY: n[a].pageY, target: n[a].target }); return c }, v = function (f, c, e, m) {
                "touch" !== f.pointerType && f.pointerType !== f.MSPOINTER_TYPE_TOUCH || !A[a.hoverChartIndex] ||
                (m(f), m = A[a.hoverChartIndex].pointer, m[c]({ type: e, target: f.currentTarget, preventDefault: d, touches: h() }))
            }; k(g.prototype, {
                onContainerPointerDown: function (a) { v(a, "onContainerTouchStart", "touchstart", function (a) { n[a.pointerId] = { pageX: a.pageX, pageY: a.pageY, target: a.currentTarget } }) }, onContainerPointerMove: function (a) { v(a, "onContainerTouchMove", "touchmove", function (a) { n[a.pointerId] = { pageX: a.pageX, pageY: a.pageY }; n[a.pointerId].target || (n[a.pointerId].target = a.currentTarget) }) }, onDocumentPointerUp: function (a) {
                    v(a,
                    "onDocumentTouchEnd", "touchend", function (a) { delete n[a.pointerId] })
                }, batchMSEvents: function (a) { a(this.chart.container, f ? "pointerdown" : "MSPointerDown", this.onContainerPointerDown); a(this.chart.container, f ? "pointermove" : "MSPointerMove", this.onContainerPointerMove); a(F, f ? "pointerup" : "MSPointerUp", this.onDocumentPointerUp) }
            }); t(g.prototype, "init", function (a, c, e) { a.call(this, c, e); this.hasZoom && D(c.container, { "-ms-touch-action": "none", "touch-action": "none" }) }); t(g.prototype, "setDOMEvents", function (a) {
                a.apply(this);
                (this.hasZoom || this.followTouchMove) && this.batchMSEvents(C)
            }); t(g.prototype, "destroy", function (a) { this.batchMSEvents(u); a.call(this) })
        }
    })(M); (function (a) {
        var C, A = a.addEvent, D = a.css, F = a.discardElement, k = a.defined, d = a.each, g = a.extend, u = a.isFirefox, l = a.marginNames, t = a.merge, n = a.pick, f = a.setAnimation, h = a.stableSort, v = a.win, H = a.wrap; C = a.Legend = function (a, e) { this.init(a, e) }; C.prototype = {
            init: function (a, e) { this.chart = a; this.setOptions(e); e.enabled && (this.render(), A(this.chart, "endResize", function () { this.legend.positionCheckboxes() })) },
            setOptions: function (a) { var c = n(a.padding, 8); this.options = a; this.itemStyle = a.itemStyle; this.itemHiddenStyle = t(this.itemStyle, a.itemHiddenStyle); this.itemMarginTop = a.itemMarginTop || 0; this.initialItemX = this.padding = c; this.initialItemY = c - 5; this.itemHeight = this.maxItemWidth = 0; this.symbolWidth = n(a.symbolWidth, 16); this.pages = [] }, update: function (a, e) { var c = this.chart; this.setOptions(t(!0, this.options, a)); this.destroy(); c.isDirtyLegend = c.isDirtyBox = !0; n(e, !0) && c.redraw() }, colorizeItem: function (a, e) {
                a.legendGroup[e ?
                "removeClass" : "addClass"]("highcharts-legend-item-hidden"); var c = this.options, f = a.legendItem, d = a.legendLine, b = a.legendSymbol, h = this.itemHiddenStyle.color, c = e ? c.itemStyle.color : h, g = e ? a.color || h : h, l = a.options && a.options.marker, k = { fill: g }, n; f && f.css({ fill: c, color: c }); d && d.attr({ stroke: g }); if (b) { if (l && b.isMarker && (k = a.pointAttribs(), !e)) for (n in k) k[n] = h; b.attr(k) }
            }, positionItem: function (a) {
                var c = this.options, f = c.symbolPadding, c = !c.rtl, d = a._legendItemPos, h = d[0], d = d[1], b = a.checkbox; (a = a.legendGroup) &&
                a.element && a.translate(c ? h : this.legendWidth - h - 2 * f - 4, d); b && (b.x = h, b.y = d)
            }, destroyItem: function (a) { var c = a.checkbox; d(["legendItem", "legendLine", "legendSymbol", "legendGroup"], function (c) { a[c] && (a[c] = a[c].destroy()) }); c && F(a.checkbox) }, destroy: function () { var a = this.group, e = this.box; e && (this.box = e.destroy()); d(this.getAllItems(), function (a) { d(["legendItem", "legendGroup"], function (c) { a[c] && (a[c] = a[c].destroy()) }) }); a && (this.group = a.destroy()); this.display = null }, positionCheckboxes: function (a) {
                var c = this.group &&
                this.group.alignAttr, f, h = this.clipHeight || this.legendHeight, g = this.titleHeight; c && (f = c.translateY, d(this.allItems, function (b) { var e = b.checkbox, d; e && (d = f + g + e.y + (a || 0) + 3, D(e, { left: c.translateX + b.checkboxOffset + e.x - 20 + "px", top: d + "px", display: d > f - 6 && d < f + h - 6 ? "" : "none" })) }))
            }, renderTitle: function () {
                var a = this.padding, e = this.options.title, f = 0; e.text && (this.title || (this.title = this.chart.renderer.label(e.text, a - 3, a - 4, null, null, null, null, null, "legend-title").attr({ zIndex: 1 }).css(e.style).add(this.group)), a =
                this.title.getBBox(), f = a.height, this.offsetWidth = a.width, this.contentGroup.attr({ translateY: f })); this.titleHeight = f
            }, setText: function (c) { var e = this.options; c.legendItem.attr({ text: e.labelFormat ? a.format(e.labelFormat, c) : e.labelFormatter.call(c) }) }, renderItem: function (a) {
                var c = this.chart, f = c.renderer, d = this.options, h = "horizontal" === d.layout, b = this.symbolWidth, g = d.symbolPadding, l = this.itemStyle, k = this.itemHiddenStyle, v = this.padding, u = h ? n(d.itemDistance, 20) : 0, w = !d.rtl, K = d.width, G = d.itemMarginBottom ||
                0, N = this.itemMarginTop, p = this.initialItemX, y = a.legendItem, H = !a.series, O = !H && a.series.drawLegendSymbol ? a.series : a, B = O.options, B = this.createCheckboxForItem && B && B.showCheckbox, z = d.useHTML; y || (a.legendGroup = f.g("legend-item").addClass("highcharts-" + O.type + "-series highcharts-color-" + a.colorIndex + (a.options.className ? " " + a.options.className : "") + (H ? " highcharts-series-" + a.index : "")).attr({ zIndex: 1 }).add(this.scrollGroup), a.legendItem = y = f.text("", w ? b + g : -g, this.baseline || 0, z).css(t(a.visible ? l : k)).attr({
                    align: w ?
                    "left" : "right", zIndex: 2
                }).add(a.legendGroup), this.baseline || (l = l.fontSize, this.fontMetrics = f.fontMetrics(l, y), this.baseline = this.fontMetrics.f + 3 + N, y.attr("y", this.baseline)), O.drawLegendSymbol(this, a), this.setItemEvents && this.setItemEvents(a, y, z), B && this.createCheckboxForItem(a)); this.colorizeItem(a, a.visible); this.setText(a); f = y.getBBox(); b = a.checkboxOffset = d.itemWidth || a.legendItemWidth || b + g + f.width + u + (B ? 20 : 0); this.itemHeight = g = Math.round(a.legendItemHeight || f.height); h && this.itemX - p + b > (K || c.chartWidth -
                2 * v - p - d.x) && (this.itemX = p, this.itemY += N + this.lastLineHeight + G, this.lastLineHeight = 0); this.maxItemWidth = Math.max(this.maxItemWidth, b); this.lastItemY = N + this.itemY + G; this.lastLineHeight = Math.max(g, this.lastLineHeight); a._legendItemPos = [this.itemX, this.itemY]; h ? this.itemX += b : (this.itemY += N + g + G, this.lastLineHeight = g); this.offsetWidth = K || Math.max((h ? this.itemX - p - u : b) + v, this.offsetWidth)
            }, getAllItems: function () {
                var a = []; d(this.chart.series, function (c) {
                    var e = c && c.options; c && n(e.showInLegend, k(e.linkedTo) ?
                    !1 : void 0, !0) && (a = a.concat(c.legendItems || ("point" === e.legendType ? c.data : c)))
                }); return a
            }, adjustMargins: function (a, e) { var c = this.chart, f = this.options, h = f.align.charAt(0) + f.verticalAlign.charAt(0) + f.layout.charAt(0); f.floating || d([/(lth|ct|rth)/, /(rtv|rm|rbv)/, /(rbh|cb|lbh)/, /(lbv|lm|ltv)/], function (b, d) { b.test(h) && !k(a[d]) && (c[l[d]] = Math.max(c[l[d]], c.legend[(d + 1) % 2 ? "legendHeight" : "legendWidth"] + [1, -1, -1, 1][d] * f[d % 2 ? "x" : "y"] + n(f.margin, 12) + e[d])) }) }, render: function () {
                var a = this, e = a.chart, f = e.renderer,
                l = a.group, k, b, q, n, t = a.box, v = a.options, u = a.padding; a.itemX = a.initialItemX; a.itemY = a.initialItemY; a.offsetWidth = 0; a.lastItemY = 0; l || (a.group = l = f.g("legend").attr({ zIndex: 7 }).add(), a.contentGroup = f.g().attr({ zIndex: 1 }).add(l), a.scrollGroup = f.g().add(a.contentGroup)); a.renderTitle(); k = a.getAllItems(); h(k, function (a, b) { return (a.options && a.options.legendIndex || 0) - (b.options && b.options.legendIndex || 0) }); v.reversed && k.reverse(); a.allItems = k; a.display = b = !!k.length; a.lastLineHeight = 0; d(k, function (b) { a.renderItem(b) });
                q = (v.width || a.offsetWidth) + u; n = a.lastItemY + a.lastLineHeight + a.titleHeight; n = a.handleOverflow(n); n += u; t || (a.box = t = f.rect().addClass("highcharts-legend-box").attr({ r: v.borderRadius }).add(l), t.isNew = !0); t.attr({ stroke: v.borderColor, "stroke-width": v.borderWidth || 0, fill: v.backgroundColor || "none" }).shadow(v.shadow); 0 < q && 0 < n && (t[t.isNew ? "attr" : "animate"](t.crisp({ x: 0, y: 0, width: q, height: n }, t.strokeWidth())), t.isNew = !1); t[b ? "show" : "hide"](); a.legendWidth = q; a.legendHeight = n; d(k, function (b) { a.positionItem(b) });
                b && l.align(g({ width: q, height: n }, v), !0, "spacingBox"); e.isResizing || this.positionCheckboxes()
            }, handleOverflow: function (a) {
                var c = this, f = this.chart, h = f.renderer, g = this.options, b = g.y, f = f.spacingBox.height + ("top" === g.verticalAlign ? -b : b) - this.padding, b = g.maxHeight, q, l = this.clipRect, k = g.navigation, t = n(k.animation, !0), v = k.arrowSize || 12, w = this.nav, K = this.pages, G = this.padding, u, p = this.allItems, y = function (a) {
                    a ? l.attr({ height: a }) : l && (c.clipRect = l.destroy(), c.contentGroup.clip()); c.contentGroup.div && (c.contentGroup.div.style.clip =
                    a ? "rect(" + G + "px,9999px," + (G + a) + "px,0)" : "auto")
                }; "horizontal" !== g.layout || "middle" === g.verticalAlign || g.floating || (f /= 2); b && (f = Math.min(f, b)); K.length = 0; a > f && !1 !== k.enabled ? (this.clipHeight = q = Math.max(f - 20 - this.titleHeight - G, 0), this.currentPage = n(this.currentPage, 1), this.fullHeight = a, d(p, function (a, b) { var c = a._legendItemPos[1]; a = Math.round(a.legendItem.getBBox().height); var e = K.length; if (!e || c - K[e - 1] > q && (u || c) !== K[e - 1]) K.push(u || c), e++; b === p.length - 1 && c + a - K[e - 1] > q && K.push(c); c !== u && (u = c) }), l || (l = c.clipRect =
                h.clipRect(0, G, 9999, 0), c.contentGroup.clip(l)), y(q), w || (this.nav = w = h.g().attr({ zIndex: 1 }).add(this.group), this.up = h.symbol("triangle", 0, 0, v, v).on("click", function () { c.scroll(-1, t) }).add(w), this.pager = h.text("", 15, 10).addClass("highcharts-legend-navigation").css(k.style).add(w), this.down = h.symbol("triangle-down", 0, 0, v, v).on("click", function () { c.scroll(1, t) }).add(w)), c.scroll(0), a = f) : w && (y(), w.hide(), this.scrollGroup.attr({ translateY: 1 }), this.clipHeight = 0); return a
            }, scroll: function (a, e) {
                var c = this.pages,
                d = c.length; a = this.currentPage + a; var h = this.clipHeight, b = this.options.navigation, g = this.pager, l = this.padding; a > d && (a = d); 0 < a && (void 0 !== e && f(e, this.chart), this.nav.attr({ translateX: l, translateY: h + this.padding + 7 + this.titleHeight, visibility: "visible" }), this.up.attr({ "class": 1 === a ? "highcharts-legend-nav-inactive" : "highcharts-legend-nav-active" }), g.attr({ text: a + "/" + d }), this.down.attr({ x: 18 + this.pager.getBBox().width, "class": a === d ? "highcharts-legend-nav-inactive" : "highcharts-legend-nav-active" }), this.up.attr({
                    fill: 1 ===
                    a ? b.inactiveColor : b.activeColor
                }).css({ cursor: 1 === a ? "default" : "pointer" }), this.down.attr({ fill: a === d ? b.inactiveColor : b.activeColor }).css({ cursor: a === d ? "default" : "pointer" }), e = -c[a - 1] + this.initialItemY, this.scrollGroup.animate({ translateY: e }), this.currentPage = a, this.positionCheckboxes(e))
            }
        }; a.LegendSymbolMixin = {
            drawRectangle: function (a, e) {
                var c = a.options, f = c.symbolHeight || a.fontMetrics.f, c = c.squareSymbol; e.legendSymbol = this.chart.renderer.rect(c ? (a.symbolWidth - f) / 2 : 0, a.baseline - f + 1, c ? f : a.symbolWidth,
                f, n(a.options.symbolRadius, f / 2)).addClass("highcharts-point").attr({ zIndex: 3 }).add(e.legendGroup)
            }, drawLineMarker: function (a) {
                var c = this.options, f = c.marker, d = a.symbolWidth, h = this.chart.renderer, b = this.legendGroup; a = a.baseline - Math.round(.3 * a.fontMetrics.b); var g; g = { "stroke-width": c.lineWidth || 0 }; c.dashStyle && (g.dashstyle = c.dashStyle); this.legendLine = h.path(["M", 0, a, "L", d, a]).addClass("highcharts-graph").attr(g).add(b); f && !1 !== f.enabled && (c = 0 === this.symbol.indexOf("url") ? 0 : f.radius, this.legendSymbol =
                f = h.symbol(this.symbol, d / 2 - c, a - c, 2 * c, 2 * c, f).addClass("highcharts-point").add(b), f.isMarker = !0)
            }
        }; (/Trident\/7\.0/.test(v.navigator.userAgent) || u) && H(C.prototype, "positionItem", function (a, e) { var c = this, f = function () { e._legendItemPos && a.call(c, e) }; f(); setTimeout(f) })
    })(M); (function (a) {
        var C = a.addEvent, A = a.animate, D = a.animObject, F = a.attr, k = a.doc, d = a.Axis, g = a.createElement, u = a.defaultOptions, l = a.discardElement, t = a.charts, n = a.css, f = a.defined, h = a.each, v = a.error, H = a.extend, c = a.fireEvent, e = a.getStyle, m = a.grep,
        r = a.isNumber, I = a.isObject, b = a.isString, q = a.Legend, x = a.marginNames, L = a.merge, E = a.Pointer, J = a.pick, w = a.pInt, K = a.removeEvent, G = a.seriesTypes, N = a.splat, p = a.svg, y = a.syncTimeout, P = a.win, O = a.Renderer, B = a.Chart = function () { this.getArgs.apply(this, arguments) }; a.chart = function (a, b, c) { return new B(a, b, c) }; B.prototype = {
            callbacks: [], getArgs: function () { var a = [].slice.call(arguments); if (b(a[0]) || a[0].nodeName) this.renderTo = a.shift(); this.init(a[0], a[1]) }, init: function (b, c) {
                var e, f = b.series; b.series = null; e = L(u, b);
                e.series = b.series = f; this.userOptions = b; this.respRules = []; b = e.chart; f = b.events; this.margin = []; this.spacing = []; this.bounds = { h: {}, v: {} }; this.callback = c; this.isResizing = 0; this.options = e; this.axes = []; this.series = []; this.hasCartesianSeries = b.showAxes; var d; this.index = t.length; t.push(this); a.chartCount++; if (f) for (d in f) C(this, d, f[d]); this.xAxis = []; this.yAxis = []; this.pointCount = this.colorCounter = this.symbolCounter = 0; this.firstRender()
            }, initSeries: function (a) {
                var b = this.options.chart; (b = G[a.type || b.type ||
                b.defaultSeriesType]) || v(17, !0); b = new b; b.init(this, a); return b
            }, isInsidePlot: function (a, b, c) { var e = c ? b : a; a = c ? a : b; return 0 <= e && e <= this.plotWidth && 0 <= a && a <= this.plotHeight }, redraw: function (b) {
                var e = this.axes, f = this.series, d = this.pointer, g = this.legend, p = this.isDirtyLegend, m, w, l = this.hasCartesianSeries, k = this.isDirtyBox, q = f.length, n = q, r = this.renderer, z = r.isHidden(), G = []; a.setAnimation(b, this); z && this.cloneRenderTo(); for (this.layOutTitles() ; n--;) if (b = f[n], b.options.stacking && (m = !0, b.isDirty)) { w = !0; break } if (w) for (n =
                q; n--;) b = f[n], b.options.stacking && (b.isDirty = !0); h(f, function (a) { a.isDirty && "point" === a.options.legendType && (a.updateTotals && a.updateTotals(), p = !0); a.isDirtyData && c(a, "updatedData") }); p && g.options.enabled && (g.render(), this.isDirtyLegend = !1); m && this.getStacks(); l && h(e, function (a) { a.updateNames(); a.setScale() }); this.getMargins(); l && (h(e, function (a) { a.isDirty && (k = !0) }), h(e, function (a) {
                    var b = a.min + "," + a.max; a.extKey !== b && (a.extKey = b, G.push(function () {
                        c(a, "afterSetExtremes", H(a.eventArgs, a.getExtremes()));
                        delete a.eventArgs
                    })); (k || m) && a.redraw()
                })); k && this.drawChartBox(); h(f, function (a) { (k || a.isDirty) && a.visible && a.redraw() }); d && d.reset(!0); r.draw(); c(this, "redraw"); z && this.cloneRenderTo(!0); h(G, function (a) { a.call() })
            }, get: function (a) { var b = this.axes, c = this.series, e, f; for (e = 0; e < b.length; e++) if (b[e].options.id === a) return b[e]; for (e = 0; e < c.length; e++) if (c[e].options.id === a) return c[e]; for (e = 0; e < c.length; e++) for (f = c[e].points || [], b = 0; b < f.length; b++) if (f[b].id === a) return f[b]; return null }, getAxes: function () {
                var a =
                this, b = this.options, c = b.xAxis = N(b.xAxis || {}), b = b.yAxis = N(b.yAxis || {}); h(c, function (a, b) { a.index = b; a.isX = !0 }); h(b, function (a, b) { a.index = b }); c = c.concat(b); h(c, function (b) { new d(a, b) })
            }, getSelectedPoints: function () { var a = []; h(this.series, function (b) { a = a.concat(m(b.points || [], function (a) { return a.selected })) }); return a }, getSelectedSeries: function () { return m(this.series, function (a) { return a.selected }) }, setTitle: function (a, b, c) {
                var e = this, f = e.options, d; d = f.title = L(f.title, a); f = f.subtitle = L(f.subtitle, b);
                h([["title", a, d], ["subtitle", b, f]], function (a, b) { var c = a[0], f = e[c], d = a[1]; a = a[2]; f && d && (e[c] = f = f.destroy()); a && a.text && !f && (e[c] = e.renderer.text(a.text, 0, 0, a.useHTML).attr({ align: a.align, "class": "highcharts-" + c, zIndex: a.zIndex || 4 }).add(), e[c].update = function (a) { e.setTitle(!b && a, b && a) }, e[c].css(a.style)) }); e.layOutTitles(c)
            }, layOutTitles: function (a) {
                var b = 0, c, e = this.renderer, f = this.spacingBox; h(["title", "subtitle"], function (a) {
                    var c = this[a], d = this.options[a], h; c && (h = d.style.fontSize, h = e.fontMetrics(h,
                    c).b, c.css({ width: (d.width || f.width + d.widthAdjust) + "px" }).align(H({ y: b + h + ("title" === a ? -3 : 2) }, d), !1, "spacingBox"), d.floating || d.verticalAlign || (b = Math.ceil(b + c.getBBox().height)))
                }, this); c = this.titleOffset !== b; this.titleOffset = b; !this.isDirtyBox && c && (this.isDirtyBox = c, this.hasRendered && J(a, !0) && this.isDirtyBox && this.redraw())
            }, getChartSize: function () {
                var a = this.options.chart, b = a.width, a = a.height, c = this.renderToClone || this.renderTo; f(b) || (this.containerWidth = e(c, "width")); f(a) || (this.containerHeight =
                e(c, "height")); this.chartWidth = Math.max(0, b || this.containerWidth || 600); this.chartHeight = Math.max(0, J(a, 19 < this.containerHeight ? this.containerHeight : 400))
            }, cloneRenderTo: function (a) {
                var b = this.renderToClone, c = this.container; if (a) { if (b) { for (; b.childNodes.length;) this.renderTo.appendChild(b.firstChild); l(b); delete this.renderToClone } } else c && c.parentNode === this.renderTo && this.renderTo.removeChild(c), this.renderToClone = b = this.renderTo.cloneNode(0), n(b, { position: "absolute", top: "-9999px", display: "block" }),
                b.style.setProperty && b.style.setProperty("display", "block", "important"), k.body.appendChild(b), c && b.appendChild(c)
            }, setClassName: function (a) { this.container.className = "highcharts-container " + (a || "") }, getContainer: function () {
                var c, e = this.options, f = e.chart, d, h; c = this.renderTo; var p = a.uniqueKey(), m; c || (this.renderTo = c = f.renderTo); b(c) && (this.renderTo = c = k.getElementById(c)); c || v(13, !0); d = w(F(c, "data-highcharts-chart")); r(d) && t[d] && t[d].hasRendered && t[d].destroy(); F(c, "data-highcharts-chart", this.index);
                c.innerHTML = ""; f.skipClone || c.offsetWidth || this.cloneRenderTo(); this.getChartSize(); d = this.chartWidth; h = this.chartHeight; m = H({ position: "relative", overflow: "hidden", width: d + "px", height: h + "px", textAlign: "left", lineHeight: "normal", zIndex: 0, "-webkit-tap-highlight-color": "rgba(0,0,0,0)" }, f.style); this.container = c = g("div", { id: p }, m, this.renderToClone || c); this._cursor = c.style.cursor; this.renderer = new (a[f.renderer] || O)(c, d, h, null, f.forExport, e.exporting && e.exporting.allowHTML); this.setClassName(f.className);
                this.renderer.setStyle(f.style); this.renderer.chartIndex = this.index
            }, getMargins: function (a) { var b = this.spacing, c = this.margin, e = this.titleOffset; this.resetMargins(); e && !f(c[0]) && (this.plotTop = Math.max(this.plotTop, e + this.options.title.margin + b[0])); this.legend.display && this.legend.adjustMargins(c, b); this.extraBottomMargin && (this.marginBottom += this.extraBottomMargin); this.extraTopMargin && (this.plotTop += this.extraTopMargin); a || this.getAxisMargins() }, getAxisMargins: function () {
                var a = this, b = a.axisOffset =
                [0, 0, 0, 0], c = a.margin; a.hasCartesianSeries && h(a.axes, function (a) { a.visible && a.getOffset() }); h(x, function (e, d) { f(c[d]) || (a[e] += b[d]) }); a.setChartSize()
            }, reflow: function (a) {
                var b = this, c = b.options.chart, d = b.renderTo, h = f(c.width), g = c.width || e(d, "width"), c = c.height || e(d, "height"), d = a ? a.target : P; if (!h && !b.isPrinting && g && c && (d === P || d === k)) {
                    if (g !== b.containerWidth || c !== b.containerHeight) clearTimeout(b.reflowTimeout), b.reflowTimeout = y(function () { b.container && b.setSize(void 0, void 0, !1) }, a ? 100 : 0); b.containerWidth =
                    g; b.containerHeight = c
                }
            }, initReflow: function () { var a = this, b; b = C(P, "resize", function (b) { a.reflow(b) }); C(a, "destroy", b) }, setSize: function (b, e, f) {
                var d = this, g = d.renderer; d.isResizing += 1; a.setAnimation(f, d); d.oldChartHeight = d.chartHeight; d.oldChartWidth = d.chartWidth; void 0 !== b && (d.options.chart.width = b); void 0 !== e && (d.options.chart.height = e); d.getChartSize(); b = g.globalAnimation; (b ? A : n)(d.container, { width: d.chartWidth + "px", height: d.chartHeight + "px" }, b); d.setChartSize(!0); g.setSize(d.chartWidth, d.chartHeight,
                f); h(d.axes, function (a) { a.isDirty = !0; a.setScale() }); d.isDirtyLegend = !0; d.isDirtyBox = !0; d.layOutTitles(); d.getMargins(); d.setResponsive && d.setResponsive(!1); d.redraw(f); d.oldChartHeight = null; c(d, "resize"); y(function () { d && c(d, "endResize", null, function () { --d.isResizing }) }, D(b).duration)
            }, setChartSize: function (a) {
                var b = this.inverted, c = this.renderer, e = this.chartWidth, f = this.chartHeight, d = this.options.chart, g = this.spacing, p = this.clipOffset, m, w, l, k; this.plotLeft = m = Math.round(this.plotLeft); this.plotTop =
                w = Math.round(this.plotTop); this.plotWidth = l = Math.max(0, Math.round(e - m - this.marginRight)); this.plotHeight = k = Math.max(0, Math.round(f - w - this.marginBottom)); this.plotSizeX = b ? k : l; this.plotSizeY = b ? l : k; this.plotBorderWidth = d.plotBorderWidth || 0; this.spacingBox = c.spacingBox = { x: g[3], y: g[0], width: e - g[3] - g[1], height: f - g[0] - g[2] }; this.plotBox = c.plotBox = { x: m, y: w, width: l, height: k }; e = 2 * Math.floor(this.plotBorderWidth / 2); b = Math.ceil(Math.max(e, p[3]) / 2); c = Math.ceil(Math.max(e, p[0]) / 2); this.clipBox = {
                    x: b, y: c, width: Math.floor(this.plotSizeX -
                    Math.max(e, p[1]) / 2 - b), height: Math.max(0, Math.floor(this.plotSizeY - Math.max(e, p[2]) / 2 - c))
                }; a || h(this.axes, function (a) { a.setAxisSize(); a.setAxisTranslation() })
            }, resetMargins: function () { var a = this, b = a.options.chart; h(["margin", "spacing"], function (c) { var e = b[c], f = I(e) ? e : [e, e, e, e]; h(["Top", "Right", "Bottom", "Left"], function (e, d) { a[c][d] = J(b[c + e], f[d]) }) }); h(x, function (b, c) { a[b] = J(a.margin[c], a.spacing[c]) }); a.axisOffset = [0, 0, 0, 0]; a.clipOffset = [0, 0, 0, 0] }, drawChartBox: function () {
                var a = this.options.chart,
                b = this.renderer, c = this.chartWidth, e = this.chartHeight, f = this.chartBackground, d = this.plotBackground, h = this.plotBorder, g, p = this.plotBGImage, m = a.backgroundColor, w = a.plotBackgroundColor, l = a.plotBackgroundImage, k, q = this.plotLeft, n = this.plotTop, r = this.plotWidth, G = this.plotHeight, t = this.plotBox, x = this.clipRect, K = this.clipBox, v = "animate"; f || (this.chartBackground = f = b.rect().addClass("highcharts-background").add(), v = "attr"); g = a.borderWidth || 0; k = g + (a.shadow ? 8 : 0); m = { fill: m || "none" }; if (g || f["stroke-width"]) m.stroke =
                a.borderColor, m["stroke-width"] = g; f.attr(m).shadow(a.shadow); f[v]({ x: k / 2, y: k / 2, width: c - k - g % 2, height: e - k - g % 2, r: a.borderRadius }); v = "animate"; d || (v = "attr", this.plotBackground = d = b.rect().addClass("highcharts-plot-background").add()); d[v](t); d.attr({ fill: w || "none" }).shadow(a.plotShadow); l && (p ? p.animate(t) : this.plotBGImage = b.image(l, q, n, r, G).add()); x ? x.animate({ width: K.width, height: K.height }) : this.clipRect = b.clipRect(K); v = "animate"; h || (v = "attr", this.plotBorder = h = b.rect().addClass("highcharts-plot-border").attr({ zIndex: 1 }).add());
                h.attr({ stroke: a.plotBorderColor, "stroke-width": a.plotBorderWidth || 0, fill: "none" }); h[v](h.crisp({ x: q, y: n, width: r, height: G }, -h.strokeWidth())); this.isDirtyBox = !1
            }, propFromSeries: function () { var a = this, b = a.options.chart, c, e = a.options.series, f, d; h(["inverted", "angular", "polar"], function (h) { c = G[b.type || b.defaultSeriesType]; d = b[h] || c && c.prototype[h]; for (f = e && e.length; !d && f--;) (c = G[e[f].type]) && c.prototype[h] && (d = !0); a[h] = d }) }, linkSeries: function () {
                var a = this, c = a.series; h(c, function (a) {
                    a.linkedSeries.length =
                    0
                }); h(c, function (c) { var e = c.options.linkedTo; b(e) && (e = ":previous" === e ? a.series[c.index - 1] : a.get(e)) && e.linkedParent !== c && (e.linkedSeries.push(c), c.linkedParent = e, c.visible = J(c.options.visible, e.options.visible, c.visible)) })
            }, renderSeries: function () { h(this.series, function (a) { a.translate(); a.render() }) }, renderLabels: function () {
                var a = this, b = a.options.labels; b.items && h(b.items, function (c) {
                    var e = H(b.style, c.style), f = w(e.left) + a.plotLeft, d = w(e.top) + a.plotTop + 12; delete e.left; delete e.top; a.renderer.text(c.html,
                    f, d).attr({ zIndex: 2 }).css(e).add()
                })
            }, render: function () {
                var a = this.axes, b = this.renderer, c = this.options, e, f, d; this.setTitle(); this.legend = new q(this, c.legend); this.getStacks && this.getStacks(); this.getMargins(!0); this.setChartSize(); c = this.plotWidth; e = this.plotHeight -= 21; h(a, function (a) { a.setScale() }); this.getAxisMargins(); f = 1.1 < c / this.plotWidth; d = 1.05 < e / this.plotHeight; if (f || d) h(a, function (a) { (a.horiz && f || !a.horiz && d) && a.setTickInterval(!0) }), this.getMargins(); this.drawChartBox(); this.hasCartesianSeries &&
                h(a, function (a) { a.visible && a.render() }); this.seriesGroup || (this.seriesGroup = b.g("series-group").attr({ zIndex: 3 }).add()); this.renderSeries(); this.renderLabels(); this.addCredits(); this.setResponsive && this.setResponsive(); this.hasRendered = !0
            }, addCredits: function (a) {
                var b = this; a = L(!0, this.options.credits, a); a.enabled && !this.credits && (this.credits = this.renderer.text(a.text + (this.mapCredits || ""), 0, 0).addClass("highcharts-credits").on("click", function () { a.href && (P.location.href = a.href) }).attr({
                    align: a.position.align,
                    zIndex: 8
                }).css(a.style).add().align(a.position), this.credits.update = function (a) { b.credits = b.credits.destroy(); b.addCredits(a) })
            }, destroy: function () {
                var b = this, e = b.axes, f = b.series, d = b.container, g, p = d && d.parentNode; c(b, "destroy"); t[b.index] = void 0; a.chartCount--; b.renderTo.removeAttribute("data-highcharts-chart"); K(b); for (g = e.length; g--;) e[g] = e[g].destroy(); this.scroller && this.scroller.destroy && this.scroller.destroy(); for (g = f.length; g--;) f[g] = f[g].destroy(); h("title subtitle chartBackground plotBackground plotBGImage plotBorder seriesGroup clipRect credits pointer rangeSelector legend resetZoomButton tooltip renderer".split(" "),
                function (a) { var c = b[a]; c && c.destroy && (b[a] = c.destroy()) }); d && (d.innerHTML = "", K(d), p && l(d)); for (g in b) delete b[g]
            }, isReadyToRender: function () { var a = this; return p || P != P.top || "complete" === k.readyState ? !0 : (k.attachEvent("onreadystatechange", function () { k.detachEvent("onreadystatechange", a.firstRender); "complete" === k.readyState && a.firstRender() }), !1) }, firstRender: function () {
                var a = this, b = a.options; if (a.isReadyToRender()) {
                    a.getContainer(); c(a, "init"); a.resetMargins(); a.setChartSize(); a.propFromSeries();
                    a.getAxes(); h(b.series || [], function (b) { a.initSeries(b) }); a.linkSeries(); c(a, "beforeRender"); E && (a.pointer = new E(a, b)); a.render(); a.renderer.draw(); if (!a.renderer.imgCount && a.onload) a.onload(); a.cloneRenderTo(!0)
                }
            }, onload: function () { h([this.callback].concat(this.callbacks), function (a) { a && void 0 !== this.index && a.apply(this, [this]) }, this); c(this, "load"); !1 !== this.options.chart.reflow && this.initReflow(); this.onload = null }
        }
    })(M); (function (a) {
        var C, A = a.each, D = a.extend, F = a.erase, k = a.fireEvent, d = a.format, g =
        a.isArray, u = a.isNumber, l = a.pick, t = a.removeEvent; C = a.Point = function () { }; C.prototype = {
            init: function (a, f, d) { this.series = a; this.color = a.color; this.applyOptions(f, d); a.options.colorByPoint ? (f = a.options.colors || a.chart.options.colors, this.color = this.color || f[a.colorCounter], f = f.length, d = a.colorCounter, a.colorCounter++, a.colorCounter === f && (a.colorCounter = 0)) : d = a.colorIndex; this.colorIndex = l(this.colorIndex, d); a.chart.pointCount++; return this }, applyOptions: function (a, f) {
                var d = this.series, g = d.options.pointValKey ||
                d.pointValKey; a = C.prototype.optionsToObject.call(this, a); D(this, a); this.options = this.options ? D(this.options, a) : a; a.group && delete this.group; g && (this.y = this[g]); this.isNull = l(this.isValid && !this.isValid(), null === this.x || !u(this.y, !0)); this.selected && (this.state = "select"); "name" in this && void 0 === f && d.xAxis && d.xAxis.hasNames && (this.x = d.xAxis.nameToX(this)); void 0 === this.x && d && (this.x = void 0 === f ? d.autoIncrement(this) : f); return this
            }, optionsToObject: function (a) {
                var f = {}, d = this.series, l = d.options.keys,
                k = l || d.pointArrayMap || ["y"], c = k.length, e = 0, m = 0; if (u(a) || null === a) f[k[0]] = a; else if (g(a)) for (!l && a.length > c && (d = typeof a[0], "string" === d ? f.name = a[0] : "number" === d && (f.x = a[0]), e++) ; m < c;) l && void 0 === a[e] || (f[k[m]] = a[e]), e++, m++; else "object" === typeof a && (f = a, a.dataLabels && (d._hasPointLabels = !0), a.marker && (d._hasPointMarkers = !0)); return f
            }, getClassName: function () {
                return "highcharts-point" + (this.selected ? " highcharts-point-select" : "") + (this.negative ? " highcharts-negative" : "") + (this.isNull ? " highcharts-null-point" :
                "") + (void 0 !== this.colorIndex ? " highcharts-color-" + this.colorIndex : "") + (this.options.className ? " " + this.options.className : "")
            }, getZone: function () { var a = this.series, f = a.zones, a = a.zoneAxis || "y", d = 0, g; for (g = f[d]; this[a] >= g.value;) g = f[++d]; g && g.color && !this.options.color && (this.color = g.color); return g }, destroy: function () {
                var a = this.series.chart, f = a.hoverPoints, d; a.pointCount--; f && (this.setState(), F(f, this), f.length || (a.hoverPoints = null)); if (this === a.hoverPoint) this.onMouseOut(); if (this.graphic || this.dataLabel) t(this),
                this.destroyElements(); this.legendItem && a.legend.destroyItem(this); for (d in this) this[d] = null
            }, destroyElements: function () { for (var a = ["graphic", "dataLabel", "dataLabelUpper", "connector", "shadowGroup"], f, d = 6; d--;) f = a[d], this[f] && (this[f] = this[f].destroy()) }, getLabelConfig: function () { return { x: this.category, y: this.y, color: this.color, key: this.name || this.category, series: this.series, point: this, percentage: this.percentage, total: this.total || this.stackTotal } }, tooltipFormatter: function (a) {
                var f = this.series, g =
                f.tooltipOptions, k = l(g.valueDecimals, ""), n = g.valuePrefix || "", c = g.valueSuffix || ""; A(f.pointArrayMap || ["y"], function (e) { e = "{point." + e; if (n || c) a = a.replace(e + "}", n + e + "}" + c); a = a.replace(e + "}", e + ":,." + k + "f}") }); return d(a, { point: this, series: this.series })
            }, firePointEvent: function (a, f, d) {
                var g = this, h = this.series.options; (h.point.events[a] || g.options && g.options.events && g.options.events[a]) && this.importEvents(); "click" === a && h.allowPointSelect && (d = function (a) { g.select && g.select(null, a.ctrlKey || a.metaKey || a.shiftKey) });
                k(this, a, f, d)
            }, visible: !0
        }
    })(M); (function (a) {
        var C = a.addEvent, A = a.animObject, D = a.arrayMax, F = a.arrayMin, k = a.correctFloat, d = a.Date, g = a.defaultOptions, u = a.defaultPlotOptions, l = a.defined, t = a.each, n = a.erase, f = a.error, h = a.extend, v = a.fireEvent, H = a.grep, c = a.isArray, e = a.isNumber, m = a.isString, r = a.merge, I = a.pick, b = a.removeEvent, q = a.splat, x = a.stableSort, L = a.SVGElement, E = a.syncTimeout, J = a.win; a.Series = a.seriesType("line", null, {
            lineWidth: 2, allowPointSelect: !1, showCheckbox: !1, animation: { duration: 1E3 }, events: {},
            marker: { lineWidth: 0, lineColor: "#ffffff", radius: 4, states: { hover: { animation: { duration: 50 }, enabled: !0, radiusPlus: 2, lineWidthPlus: 1 }, select: { fillColor: "#cccccc", lineColor: "#000000", lineWidth: 2 } } }, point: { events: {} }, dataLabels: { align: "center", formatter: function () { return null === this.y ? "" : a.numberFormat(this.y, -1) }, style: { fontSize: "11px", fontWeight: "bold", color: "contrast", textOutline: "1px contrast" }, verticalAlign: "bottom", x: 0, y: 0, padding: 5 }, cropThreshold: 300, pointRange: 0, softThreshold: !0, states: {
                hover: {
                    lineWidthPlus: 1,
                    marker: {}, halo: { size: 10, opacity: .25 }
                }, select: { marker: {} }
            }, stickyTracking: !0, turboThreshold: 1E3
        }, {
            isCartesian: !0, pointClass: a.Point, sorted: !0, requireSorting: !0, directTouch: !1, axisTypes: ["xAxis", "yAxis"], colorCounter: 0, parallelArrays: ["x", "y"], coll: "series", init: function (a, b) {
                var c = this, e, f, d = a.series, g, m = function (a, b) { return I(a.options.index, a._i) - I(b.options.index, b._i) }; c.chart = a; c.options = b = c.setOptions(b); c.linkedSeries = []; c.bindAxes(); h(c, {
                    name: b.name, state: "", visible: !1 !== b.visible, selected: !0 ===
                    b.selected
                }); f = b.events; for (e in f) C(c, e, f[e]); if (f && f.click || b.point && b.point.events && b.point.events.click || b.allowPointSelect) a.runTrackerClick = !0; c.getColor(); c.getSymbol(); t(c.parallelArrays, function (a) { c[a + "Data"] = [] }); c.setData(b.data, !1); c.isCartesian && (a.hasCartesianSeries = !0); d.length && (g = d[d.length - 1]); c._i = I(g && g._i, -1) + 1; d.push(c); x(d, m); this.yAxis && x(this.yAxis.series, m); t(d, function (a, b) { a.index = b; a.name = a.name || "Series " + (b + 1) })
            }, bindAxes: function () {
                var a = this, b = a.options, c = a.chart,
                e; t(a.axisTypes || [], function (d) { t(c[d], function (c) { e = c.options; if (b[d] === e.index || void 0 !== b[d] && b[d] === e.id || void 0 === b[d] && 0 === e.index) c.series.push(a), a[d] = c, c.isDirty = !0 }); a[d] || a.optionalAxis === d || f(18, !0) })
            }, updateParallelArrays: function (a, b) { var c = a.series, f = arguments, d = e(b) ? function (e) { var f = "y" === e && c.toYData ? c.toYData(a) : a[e]; c[e + "Data"][b] = f } : function (a) { Array.prototype[b].apply(c[a + "Data"], Array.prototype.slice.call(f, 2)) }; t(c.parallelArrays, d) }, autoIncrement: function () {
                var a = this.options,
                b = this.xIncrement, c, e = a.pointIntervalUnit, b = I(b, a.pointStart, 0); this.pointInterval = c = I(this.pointInterval, a.pointInterval, 1); e && (a = new d(b), "day" === e ? a = +a[d.hcSetDate](a[d.hcGetDate]() + c) : "month" === e ? a = +a[d.hcSetMonth](a[d.hcGetMonth]() + c) : "year" === e && (a = +a[d.hcSetFullYear](a[d.hcGetFullYear]() + c)), c = a - b); this.xIncrement = b + c; return b
            }, setOptions: function (a) {
                var b = this.chart, c = b.options.plotOptions, b = b.userOptions || {}, e = b.plotOptions || {}, f = c[this.type]; this.userOptions = a; c = r(f, c.series, a); this.tooltipOptions =
                r(g.tooltip, g.plotOptions[this.type].tooltip, b.tooltip, e.series && e.series.tooltip, e[this.type] && e[this.type].tooltip, a.tooltip); null === f.marker && delete c.marker; this.zoneAxis = c.zoneAxis; a = this.zones = (c.zones || []).slice(); !c.negativeColor && !c.negativeFillColor || c.zones || a.push({ value: c[this.zoneAxis + "Threshold"] || c.threshold || 0, className: "highcharts-negative", color: c.negativeColor, fillColor: c.negativeFillColor }); a.length && l(a[a.length - 1].value) && a.push({ color: this.color, fillColor: this.fillColor });
                return c
            }, getCyclic: function (a, b, c) { var e, f = this.userOptions, d = a + "Index", g = a + "Counter", h = c ? c.length : I(this.chart.options.chart[a + "Count"], this.chart[a + "Count"]); b || (e = I(f[d], f["_" + d]), l(e) || (f["_" + d] = e = this.chart[g] % h, this.chart[g] += 1), c && (b = c[e])); void 0 !== e && (this[d] = e); this[a] = b }, getColor: function () { this.options.colorByPoint ? this.options.color = null : this.getCyclic("color", this.options.color || u[this.type].color, this.chart.options.colors) }, getSymbol: function () {
                this.getCyclic("symbol", this.options.marker.symbol,
                this.chart.options.symbols)
            }, drawLegendSymbol: a.LegendSymbolMixin.drawLineMarker, setData: function (a, b, d, g) {
                var h = this, k = h.points, l = k && k.length || 0, w, q = h.options, r = h.chart, n = null, x = h.xAxis, v = q.turboThreshold, K = this.xData, G = this.yData, E = (w = h.pointArrayMap) && w.length; a = a || []; w = a.length; b = I(b, !0); if (!1 !== g && w && l === w && !h.cropped && !h.hasGroupedData && h.visible) t(a, function (a, b) { k[b].update && a !== q.data[b] && k[b].update(a, !1, null, !1) }); else {
                    h.xIncrement = null; h.colorCounter = 0; t(this.parallelArrays, function (a) {
                        h[a +
                        "Data"].length = 0
                    }); if (v && w > v) { for (d = 0; null === n && d < w;) n = a[d], d++; if (e(n)) for (d = 0; d < w; d++) K[d] = this.autoIncrement(), G[d] = a[d]; else if (c(n)) if (E) for (d = 0; d < w; d++) n = a[d], K[d] = n[0], G[d] = n.slice(1, E + 1); else for (d = 0; d < w; d++) n = a[d], K[d] = n[0], G[d] = n[1]; else f(12) } else for (d = 0; d < w; d++) void 0 !== a[d] && (n = { series: h }, h.pointClass.prototype.applyOptions.apply(n, [a[d]]), h.updateParallelArrays(n, d)); m(G[0]) && f(14, !0); h.data = []; h.options.data = h.userOptions.data = a; for (d = l; d--;) k[d] && k[d].destroy && k[d].destroy(); x && (x.minRange =
                    x.userMinRange); h.isDirty = r.isDirtyBox = !0; h.isDirtyData = !!k; d = !1
                } "point" === q.legendType && (this.processData(), this.generatePoints()); b && r.redraw(d)
            }, processData: function (a) {
                var b = this.xData, c = this.yData, e = b.length, d; d = 0; var g, h, m = this.xAxis, k, l = this.options; k = l.cropThreshold; var w = this.getExtremesFromAll || l.getExtremesFromAll, q = this.isCartesian, l = m && m.val2lin, r = m && m.isLog, n, t; if (q && !this.isDirty && !m.isDirty && !this.yAxis.isDirty && !a) return !1; m && (a = m.getExtremes(), n = a.min, t = a.max); if (q && this.sorted &&
                !w && (!k || e > k || this.forceCrop)) if (b[e - 1] < n || b[0] > t) b = [], c = []; else if (b[0] < n || b[e - 1] > t) d = this.cropData(this.xData, this.yData, n, t), b = d.xData, c = d.yData, d = d.start, g = !0; for (k = b.length || 1; --k;) e = r ? l(b[k]) - l(b[k - 1]) : b[k] - b[k - 1], 0 < e && (void 0 === h || e < h) ? h = e : 0 > e && this.requireSorting && f(15); this.cropped = g; this.cropStart = d; this.processedXData = b; this.processedYData = c; this.closestPointRange = h
            }, cropData: function (a, b, c, e) {
                var f = a.length, d = 0, g = f, h = I(this.cropShoulder, 1), m; for (m = 0; m < f; m++) if (a[m] >= c) {
                    d = Math.max(0, m -
                    h); break
                } for (c = m; c < f; c++) if (a[c] > e) { g = c + h; break } return { xData: a.slice(d, g), yData: b.slice(d, g), start: d, end: g }
            }, generatePoints: function () {
                var a = this.options.data, b = this.data, c, e = this.processedXData, f = this.processedYData, d = this.pointClass, g = e.length, h = this.cropStart || 0, m, k = this.hasGroupedData, l, r = [], n; b || k || (b = [], b.length = a.length, b = this.data = b); for (n = 0; n < g; n++) m = h + n, k ? (l = (new d).init(this, [e[n]].concat(q(f[n]))), l.dataGroup = this.groupMap[n]) : (l = b[m]) || void 0 === a[m] || (b[m] = l = (new d).init(this, a[m], e[n])),
                l.index = m, r[n] = l; if (b && (g !== (c = b.length) || k)) for (n = 0; n < c; n++) n !== h || k || (n += g), b[n] && (b[n].destroyElements(), b[n].plotX = void 0); this.data = b; this.points = r
            }, getExtremes: function (a) {
                var b = this.yAxis, f = this.processedXData, d, g = [], h = 0; d = this.xAxis.getExtremes(); var m = d.min, k = d.max, l, q, w, n; a = a || this.stackedYData || this.processedYData || []; d = a.length; for (n = 0; n < d; n++) if (q = f[n], w = a[n], l = (e(w, !0) || c(w)) && (!b.isLog || w.length || 0 < w), q = this.getExtremesFromAll || this.options.getExtremesFromAll || this.cropped || (f[n + 1] ||
                q) >= m && (f[n - 1] || q) <= k, l && q) if (l = w.length) for (; l--;) null !== w[l] && (g[h++] = w[l]); else g[h++] = w; this.dataMin = F(g); this.dataMax = D(g)
            }, translate: function () {
                this.processedXData || this.processData(); this.generatePoints(); var a = this.options, b = a.stacking, c = this.xAxis, f = c.categories, d = this.yAxis, g = this.points, h = g.length, m = !!this.modifyValue, q = a.pointPlacement, n = "between" === q || e(q), r = a.threshold, t = a.startFromThreshold ? r : 0, x, v, E, u, J = Number.MAX_VALUE; "between" === q && (q = .5); e(q) && (q *= I(a.pointRange || c.pointRange));
                for (a = 0; a < h; a++) {
                    var L = g[a], H = L.x, A = L.y; v = L.low; var C = b && d.stacks[(this.negStacks && A < (t ? 0 : r) ? "-" : "") + this.stackKey], D; d.isLog && null !== A && 0 >= A && (L.isNull = !0); L.plotX = x = k(Math.min(Math.max(-1E5, c.translate(H, 0, 0, 0, 1, q, "flags" === this.type)), 1E5)); b && this.visible && !L.isNull && C && C[H] && (u = this.getStackIndicator(u, H, this.index), D = C[H], A = D.points[u.key], v = A[0], A = A[1], v === t && u.key === C[H].base && (v = I(r, d.min)), d.isLog && 0 >= v && (v = null), L.total = L.stackTotal = D.total, L.percentage = D.total && L.y / D.total * 100, L.stackY =
                    A, D.setOffset(this.pointXOffset || 0, this.barW || 0)); L.yBottom = l(v) ? d.translate(v, 0, 1, 0, 1) : null; m && (A = this.modifyValue(A, L)); L.plotY = v = "number" === typeof A && Infinity !== A ? Math.min(Math.max(-1E5, d.translate(A, 0, 1, 0, 1)), 1E5) : void 0; L.isInside = void 0 !== v && 0 <= v && v <= d.len && 0 <= x && x <= c.len; L.clientX = n ? k(c.translate(H, 0, 0, 0, 1, q)) : x; L.negative = L.y < (r || 0); L.category = f && void 0 !== f[L.x] ? f[L.x] : L.x; L.isNull || (void 0 !== E && (J = Math.min(J, Math.abs(x - E))), E = x)
                } this.closestPointRangePx = J
            }, getValidPoints: function (a, b) {
                var c =
                this.chart; return H(a || this.points || [], function (a) { return b && !c.isInsidePlot(a.plotX, a.plotY, c.inverted) ? !1 : !a.isNull })
            }, setClip: function (a) {
                var b = this.chart, c = this.options, e = b.renderer, f = b.inverted, d = this.clipBox, g = d || b.clipBox, h = this.sharedClipKey || ["_sharedClip", a && a.duration, a && a.easing, g.height, c.xAxis, c.yAxis].join(), m = b[h], k = b[h + "m"]; m || (a && (g.width = 0, b[h + "m"] = k = e.clipRect(-99, f ? -b.plotLeft : -b.plotTop, 99, f ? b.chartWidth : b.chartHeight)), b[h] = m = e.clipRect(g), m.count = { length: 0 }); a && !m.count[this.index] &&
                (m.count[this.index] = !0, m.count.length += 1); !1 !== c.clip && (this.group.clip(a || d ? m : b.clipRect), this.markerGroup.clip(k), this.sharedClipKey = h); a || (m.count[this.index] && (delete m.count[this.index], --m.count.length), 0 === m.count.length && h && b[h] && (d || (b[h] = b[h].destroy()), b[h + "m"] && (b[h + "m"] = b[h + "m"].destroy())))
            }, animate: function (a) {
                var b = this.chart, c = A(this.options.animation), e; a ? this.setClip(c) : (e = this.sharedClipKey, (a = b[e]) && a.animate({ width: b.plotSizeX }, c), b[e + "m"] && b[e + "m"].animate({
                    width: b.plotSizeX +
                    99
                }, c), this.animate = null)
            }, afterAnimate: function () { this.setClip(); v(this, "afterAnimate") }, drawPoints: function () {
                var a = this.points, b = this.chart, c, f, d, g, h = this.options.marker, m, k, l, q, n = this.markerGroup, r = I(h.enabled, this.xAxis.isRadial ? !0 : null, this.closestPointRangePx > 2 * h.radius); if (!1 !== h.enabled || this._hasPointMarkers) for (f = a.length; f--;) d = a[f], c = d.plotY, g = d.graphic, m = d.marker || {}, k = !!d.marker, l = r && void 0 === m.enabled || m.enabled, q = d.isInside, l && e(c) && null !== d.y ? (c = I(m.symbol, this.symbol), d.hasImage =
                0 === c.indexOf("url"), l = this.markerAttribs(d, d.selected && "select"), g ? g[q ? "show" : "hide"](!0).animate(l) : q && (0 < l.width || d.hasImage) && (d.graphic = g = b.renderer.symbol(c, l.x, l.y, l.width, l.height, k ? m : h).add(n)), g && g.attr(this.pointAttribs(d, d.selected && "select")), g && g.addClass(d.getClassName(), !0)) : g && (d.graphic = g.destroy())
            }, markerAttribs: function (a, b) {
                var c = this.options.marker, e = a && a.options, f = e && e.marker || {}, e = I(f.radius, c.radius); b && (c = c.states[b], b = f.states && f.states[b], e = I(b && b.radius, c && c.radius, e +
                (c && c.radiusPlus || 0))); a.hasImage && (e = 0); a = { x: Math.floor(a.plotX) - e, y: a.plotY - e }; e && (a.width = a.height = 2 * e); return a
            }, pointAttribs: function (a, b) {
                var c = this.options.marker, e = a && a.options, f = e && e.marker || {}, d = this.color, g = e && e.color, h = a && a.color, e = I(f.lineWidth, c.lineWidth), m; a && this.zones.length && (a = a.getZone()) && a.color && (m = a.color); d = g || m || h || d; m = f.fillColor || c.fillColor || d; d = f.lineColor || c.lineColor || d; b && (c = c.states[b], b = f.states && f.states[b] || {}, e = I(b.lineWidth, c.lineWidth, e + I(b.lineWidthPlus, c.lineWidthPlus,
                0)), m = b.fillColor || c.fillColor || m, d = b.lineColor || c.lineColor || d); return { stroke: d, "stroke-width": e, fill: m }
            }, destroy: function () {
                var a = this, c = a.chart, e = /AppleWebKit\/533/.test(J.navigator.userAgent), f, d = a.data || [], g, h, m; v(a, "destroy"); b(a); t(a.axisTypes || [], function (b) { (m = a[b]) && m.series && (n(m.series, a), m.isDirty = m.forceRedraw = !0) }); a.legendItem && a.chart.legend.destroyItem(a); for (f = d.length; f--;) (g = d[f]) && g.destroy && g.destroy(); a.points = null; clearTimeout(a.animationTimeout); for (h in a) a[h] instanceof
                L && !a[h].survive && (f = e && "group" === h ? "hide" : "destroy", a[h][f]()); c.hoverSeries === a && (c.hoverSeries = null); n(c.series, a); for (h in a) delete a[h]
            }, getGraphPath: function (a, b, c) {
                var e = this, f = e.options, d = f.step, g, h = [], m = [], k; a = a || e.points; (g = a.reversed) && a.reverse(); (d = { right: 1, center: 2 }[d] || d && 3) && g && (d = 4 - d); !f.connectNulls || b || c || (a = this.getValidPoints(a)); t(a, function (g, q) {
                    var p = g.plotX, n = g.plotY, r = a[q - 1]; (g.leftCliff || r && r.rightCliff) && !c && (k = !0); g.isNull && !l(b) && 0 < q ? k = !f.connectNulls : g.isNull && !b ? k =
                    !0 : (0 === q || k ? q = ["M", g.plotX, g.plotY] : e.getPointSpline ? q = e.getPointSpline(a, g, q) : d ? (q = 1 === d ? ["L", r.plotX, n] : 2 === d ? ["L", (r.plotX + p) / 2, r.plotY, "L", (r.plotX + p) / 2, n] : ["L", p, r.plotY], q.push("L", p, n)) : q = ["L", p, n], m.push(g.x), d && m.push(g.x), h.push.apply(h, q), k = !1)
                }); h.xMap = m; return e.graphPath = h
            }, drawGraph: function () {
                var a = this, b = this.options, c = (this.gappedPath || this.getGraphPath).call(this), e = [["graph", "highcharts-graph", b.lineColor || this.color, b.dashStyle]]; t(this.zones, function (c, f) {
                    e.push(["zone-graph-" +
                    f, "highcharts-graph highcharts-zone-graph-" + f + " " + (c.className || ""), c.color || a.color, c.dashStyle || b.dashStyle])
                }); t(e, function (e, f) {
                    var d = e[0], g = a[d]; g ? (g.endX = c.xMap, g.animate({ d: c })) : c.length && (a[d] = a.chart.renderer.path(c).addClass(e[1]).attr({ zIndex: 1 }).add(a.group), g = { stroke: e[2], "stroke-width": b.lineWidth, fill: a.fillGraph && a.color || "none" }, e[3] ? g.dashstyle = e[3] : "square" !== b.linecap && (g["stroke-linecap"] = g["stroke-linejoin"] = "round"), g = a[d].attr(g).shadow(2 > f && b.shadow)); g && (g.startX = c.xMap,
                    g.isArea = c.isArea)
                })
            }, applyZones: function () {
                var a = this, b = this.chart, c = b.renderer, e = this.zones, f, d, g = this.clips || [], h, m = this.graph, k = this.area, l = Math.max(b.chartWidth, b.chartHeight), q = this[(this.zoneAxis || "y") + "Axis"], n, r, x = b.inverted, v, E, u, L, J = !1; e.length && (m || k) && q && void 0 !== q.min && (r = q.reversed, v = q.horiz, m && m.hide(), k && k.hide(), n = q.getExtremes(), t(e, function (e, p) {
                    f = r ? v ? b.plotWidth : 0 : v ? 0 : q.toPixels(n.min); f = Math.min(Math.max(I(d, f), 0), l); d = Math.min(Math.max(Math.round(q.toPixels(I(e.value, n.max),
                    !0)), 0), l); J && (f = d = q.toPixels(n.max)); E = Math.abs(f - d); u = Math.min(f, d); L = Math.max(f, d); q.isXAxis ? (h = { x: x ? L : u, y: 0, width: E, height: l }, v || (h.x = b.plotHeight - h.x)) : (h = { x: 0, y: x ? L : u, width: l, height: E }, v && (h.y = b.plotWidth - h.y)); x && c.isVML && (h = q.isXAxis ? { x: 0, y: r ? u : L, height: h.width, width: b.chartWidth } : { x: h.y - b.plotLeft - b.spacingBox.x, y: 0, width: h.height, height: b.chartHeight }); g[p] ? g[p].animate(h) : (g[p] = c.clipRect(h), m && a["zone-graph-" + p].clip(g[p]), k && a["zone-area-" + p].clip(g[p])); J = e.value > n.max
                }), this.clips =
                g)
            }, invertGroups: function (a) { function b() { var b = { width: c.yAxis.len, height: c.xAxis.len }; t(["group", "markerGroup"], function (e) { c[e] && c[e].attr(b).invert(a) }) } var c = this, e; c.xAxis && (e = C(c.chart, "resize", b), C(c, "destroy", e), b(a), c.invertGroups = b) }, plotGroup: function (a, b, c, e, f) {
                var d = this[a], g = !d; g && (this[a] = d = this.chart.renderer.g(b).attr({ zIndex: e || .1 }).add(f), d.addClass("highcharts-series-" + this.index + " highcharts-" + this.type + "-series highcharts-color-" + this.colorIndex + " " + (this.options.className ||
                ""))); d.attr({ visibility: c })[g ? "attr" : "animate"](this.getPlotBox()); return d
            }, getPlotBox: function () { var a = this.chart, b = this.xAxis, c = this.yAxis; a.inverted && (b = c, c = this.xAxis); return { translateX: b ? b.left : a.plotLeft, translateY: c ? c.top : a.plotTop, scaleX: 1, scaleY: 1 } }, render: function () {
                var a = this, b = a.chart, c, e = a.options, f = !!a.animate && b.renderer.isSVG && A(e.animation).duration, d = a.visible ? "inherit" : "hidden", g = e.zIndex, h = a.hasRendered, m = b.seriesGroup, k = b.inverted; c = a.plotGroup("group", "series", d, g, m); a.markerGroup =
                a.plotGroup("markerGroup", "markers", d, g, m); f && a.animate(!0); c.inverted = a.isCartesian ? k : !1; a.drawGraph && (a.drawGraph(), a.applyZones()); a.drawDataLabels && a.drawDataLabels(); a.visible && a.drawPoints(); a.drawTracker && !1 !== a.options.enableMouseTracking && a.drawTracker(); a.invertGroups(k); !1 === e.clip || a.sharedClipKey || h || c.clip(b.clipRect); f && a.animate(); h || (a.animationTimeout = E(function () { a.afterAnimate() }, f)); a.isDirty = a.isDirtyData = !1; a.hasRendered = !0
            }, redraw: function () {
                var a = this.chart, b = this.isDirty ||
                this.isDirtyData, c = this.group, e = this.xAxis, f = this.yAxis; c && (a.inverted && c.attr({ width: a.plotWidth, height: a.plotHeight }), c.animate({ translateX: I(e && e.left, a.plotLeft), translateY: I(f && f.top, a.plotTop) })); this.translate(); this.render(); b && delete this.kdTree
            }, kdDimensions: 1, kdAxisArray: ["clientX", "plotY"], searchPoint: function (a, b) { var c = this.xAxis, e = this.yAxis, f = this.chart.inverted; return this.searchKDTree({ clientX: f ? c.len - a.chartY + c.pos : a.chartX - c.pos, plotY: f ? e.len - a.chartX + e.pos : a.chartY - e.pos }, b) },
            buildKDTree: function () { function a(c, e, f) { var d, g; if (g = c && c.length) return d = b.kdAxisArray[e % f], c.sort(function (a, b) { return a[d] - b[d] }), g = Math.floor(g / 2), { point: c[g], left: a(c.slice(0, g), e + 1, f), right: a(c.slice(g + 1), e + 1, f) } } var b = this, c = b.kdDimensions; delete b.kdTree; E(function () { b.kdTree = a(b.getValidPoints(null, !b.directTouch), c, c) }, b.options.kdNow ? 0 : 1) }, searchKDTree: function (a, b) {
                function c(a, b, h, m) {
                    var k = b.point, q = e.kdAxisArray[h % m], n, r, p = k; r = l(a[f]) && l(k[f]) ? Math.pow(a[f] - k[f], 2) : null; n = l(a[d]) &&
                    l(k[d]) ? Math.pow(a[d] - k[d], 2) : null; n = (r || 0) + (n || 0); k.dist = l(n) ? Math.sqrt(n) : Number.MAX_VALUE; k.distX = l(r) ? Math.sqrt(r) : Number.MAX_VALUE; q = a[q] - k[q]; n = 0 > q ? "left" : "right"; r = 0 > q ? "right" : "left"; b[n] && (n = c(a, b[n], h + 1, m), p = n[g] < p[g] ? n : k); b[r] && Math.sqrt(q * q) < p[g] && (a = c(a, b[r], h + 1, m), p = a[g] < p[g] ? a : p); return p
                } var e = this, f = this.kdAxisArray[0], d = this.kdAxisArray[1], g = b ? "distX" : "dist"; this.kdTree || this.buildKDTree(); if (this.kdTree) return c(a, this.kdTree, this.kdDimensions, this.kdDimensions)
            }
        })
    })(M); (function (a) {
        function C(a,
        d, f, g, k) { var h = a.chart.inverted; this.axis = a; this.isNegative = f; this.options = d; this.x = g; this.total = null; this.points = {}; this.stack = k; this.rightCliff = this.leftCliff = 0; this.alignOptions = { align: d.align || (h ? f ? "left" : "right" : "center"), verticalAlign: d.verticalAlign || (h ? "middle" : f ? "bottom" : "top"), y: l(d.y, h ? 4 : f ? 14 : -6), x: l(d.x, h ? f ? -6 : 6 : 0) }; this.textAlign = d.textAlign || (h ? f ? "right" : "left" : "center") } var A = a.Axis, D = a.Chart, F = a.correctFloat, k = a.defined, d = a.destroyObjectProperties, g = a.each, u = a.format, l = a.pick; a = a.Series;
        C.prototype = {
            destroy: function () { d(this, this.axis) }, render: function (a) { var d = this.options, f = d.format, f = f ? u(f, this) : d.formatter.call(this); this.label ? this.label.attr({ text: f, visibility: "hidden" }) : this.label = this.axis.chart.renderer.text(f, null, null, d.useHTML).css(d.style).attr({ align: this.textAlign, rotation: d.rotation, visibility: "hidden" }).add(a) }, setOffset: function (a, d) {
                var f = this.axis, g = f.chart, k = g.inverted, l = f.reversed, l = this.isNegative && !l || !this.isNegative && l, c = f.translate(f.usePercentage ? 100 :
                this.total, 0, 0, 0, 1), f = f.translate(0), f = Math.abs(c - f); a = g.xAxis[0].translate(this.x) + a; var e = g.plotHeight, k = { x: k ? l ? c : c - f : a, y: k ? e - a - d : l ? e - c - f : e - c, width: k ? f : d, height: k ? d : f }; if (d = this.label) d.align(this.alignOptions, null, k), k = d.alignAttr, d[!1 === this.options.crop || g.isInsidePlot(k.x, k.y) ? "show" : "hide"](!0)
            }
        }; D.prototype.getStacks = function () {
            var a = this; g(a.yAxis, function (a) { a.stacks && a.hasVisibleSeries && (a.oldStacks = a.stacks) }); g(a.series, function (d) {
                !d.options.stacking || !0 !== d.visible && !1 !== a.options.chart.ignoreHiddenSeries ||
                (d.stackKey = d.type + l(d.options.stack, ""))
            })
        }; A.prototype.buildStacks = function () { var a = this.series, d, f = l(this.options.reversedStacks, !0), g = a.length, k; if (!this.isXAxis) { this.usePercentage = !1; for (k = g; k--;) a[f ? k : g - k - 1].setStackedPoints(); for (k = g; k--;) d = a[f ? k : g - k - 1], d.setStackCliffs && d.setStackCliffs(); if (this.usePercentage) for (k = 0; k < g; k++) a[k].setPercentStacks() } }; A.prototype.renderStackTotals = function () {
            var a = this.chart, d = a.renderer, f = this.stacks, g, k, l = this.stackTotalGroup; l || (this.stackTotalGroup = l =
            d.g("stack-labels").attr({ visibility: "visible", zIndex: 6 }).add()); l.translate(a.plotLeft, a.plotTop); for (g in f) for (k in a = f[g], a) a[k].render(l)
        }; A.prototype.resetStacks = function () { var a = this.stacks, d, f; if (!this.isXAxis) for (d in a) for (f in a[d]) a[d][f].touched < this.stacksTouched ? (a[d][f].destroy(), delete a[d][f]) : (a[d][f].total = null, a[d][f].cum = 0) }; A.prototype.cleanStacks = function () { var a, d, f; if (!this.isXAxis) for (d in this.oldStacks && (a = this.stacks = this.oldStacks), a) for (f in a[d]) a[d][f].cum = a[d][f].total };
        a.prototype.setStackedPoints = function () {
            if (this.options.stacking && (!0 === this.visible || !1 === this.chart.options.chart.ignoreHiddenSeries)) {
                var a = this.processedXData, d = this.processedYData, f = [], g = d.length, v = this.options, u = v.threshold, c = v.startFromThreshold ? u : 0, e = v.stack, v = v.stacking, m = this.stackKey, r = "-" + m, A = this.negStacks, b = this.yAxis, q = b.stacks, x = b.oldStacks, L, E, J, w, K, G, D; b.stacksTouched += 1; for (K = 0; K < g; K++) G = a[K], D = d[K], L = this.getStackIndicator(L, G, this.index), w = L.key, J = (E = A && D < (c ? 0 : u)) ? r : m, q[J] || (q[J] =
                {}), q[J][G] || (x[J] && x[J][G] ? (q[J][G] = x[J][G], q[J][G].total = null) : q[J][G] = new C(b, b.options.stackLabels, E, G, e)), J = q[J][G], null !== D && (J.points[w] = J.points[this.index] = [l(J.cum, c)], k(J.cum) || (J.base = w), J.touched = b.stacksTouched, 0 < L.index && !1 === this.singleStacks && (J.points[w][0] = J.points[this.index + "," + G + ",0"][0])), "percent" === v ? (E = E ? m : r, A && q[E] && q[E][G] ? (E = q[E][G], J.total = E.total = Math.max(E.total, J.total) + Math.abs(D) || 0) : J.total = F(J.total + (Math.abs(D) || 0))) : J.total = F(J.total + (D || 0)), J.cum = l(J.cum, c) +
                (D || 0), null !== D && (J.points[w].push(J.cum), f[K] = J.cum); "percent" === v && (b.usePercentage = !0); this.stackedYData = f; b.oldStacks = {}
            }
        }; a.prototype.setPercentStacks = function () { var a = this, d = a.stackKey, f = a.yAxis.stacks, h = a.processedXData, k; g([d, "-" + d], function (d) { for (var c = h.length, e, g; c--;) if (e = h[c], k = a.getStackIndicator(k, e, a.index, d), e = (g = f[d] && f[d][e]) && g.points[k.key]) g = g.total ? 100 / g.total : 0, e[0] = F(e[0] * g), e[1] = F(e[1] * g), a.stackedYData[c] = e[1] }) }; a.prototype.getStackIndicator = function (a, d, f, g) {
            !k(a) || a.x !==
            d || g && a.key !== g ? a = { x: d, index: 0, key: g } : a.index++; a.key = [f, d, a.index].join(); return a
        }
    })(M); (function (a) {
        var C = a.addEvent, A = a.animate, D = a.Axis, F = a.createElement, k = a.css, d = a.defined, g = a.each, u = a.erase, l = a.extend, t = a.fireEvent, n = a.inArray, f = a.isNumber, h = a.isObject, v = a.merge, H = a.pick, c = a.Point, e = a.Series, m = a.seriesTypes, r = a.setAnimation, I = a.splat; l(a.Chart.prototype, {
            addSeries: function (a, c, e) {
                var b, f = this; a && (c = H(c, !0), t(f, "addSeries", { options: a }, function () {
                    b = f.initSeries(a); f.isDirtyLegend = !0; f.linkSeries();
                    c && f.redraw(e)
                })); return b
            }, addAxis: function (a, c, e, f) { var b = c ? "xAxis" : "yAxis", d = this.options; a = v(a, { index: this[b].length, isX: c }); new D(this, a); d[b] = I(d[b] || {}); d[b].push(a); H(e, !0) && this.redraw(f) }, showLoading: function (a) {
                var b = this, c = b.options, e = b.loadingDiv, f = c.loading, d = function () { e && k(e, { left: b.plotLeft + "px", top: b.plotTop + "px", width: b.plotWidth + "px", height: b.plotHeight + "px" }) }; e || (b.loadingDiv = e = F("div", { className: "highcharts-loading highcharts-loading-hidden" }, null, b.container), b.loadingSpan =
                F("span", { className: "highcharts-loading-inner" }, null, e), C(b, "redraw", d)); e.className = "highcharts-loading"; b.loadingSpan.innerHTML = a || c.lang.loading; k(e, l(f.style, { zIndex: 10 })); k(b.loadingSpan, f.labelStyle); b.loadingShown || (k(e, { opacity: 0, display: "" }), A(e, { opacity: f.style.opacity || .5 }, { duration: f.showDuration || 0 })); b.loadingShown = !0; d()
            }, hideLoading: function () {
                var a = this.options, c = this.loadingDiv; c && (c.className = "highcharts-loading highcharts-loading-hidden", A(c, { opacity: 0 }, {
                    duration: a.loading.hideDuration ||
                    100, complete: function () { k(c, { display: "none" }) }
                })); this.loadingShown = !1
            }, propsRequireDirtyBox: "backgroundColor borderColor borderWidth margin marginTop marginRight marginBottom marginLeft spacing spacingTop spacingRight spacingBottom spacingLeft borderRadius plotBackgroundColor plotBackgroundImage plotBorderColor plotBorderWidth plotShadow shadow".split(" "), propsRequireUpdateSeries: "chart.inverted chart.polar chart.ignoreHiddenSeries chart.type colors plotOptions".split(" "), update: function (a, c) {
                var b,
                e = { credits: "addCredits", title: "setTitle", subtitle: "setSubtitle" }, h = a.chart, m, k; if (h) { v(!0, this.options.chart, h); "className" in h && this.setClassName(h.className); if ("inverted" in h || "polar" in h) this.propFromSeries(), m = !0; for (b in h) h.hasOwnProperty(b) && (-1 !== n("chart." + b, this.propsRequireUpdateSeries) && (k = !0), -1 !== n(b, this.propsRequireDirtyBox) && (this.isDirtyBox = !0)); "style" in h && this.renderer.setStyle(h.style) } for (b in a) {
                    if (this[b] && "function" === typeof this[b].update) this[b].update(a[b], !1); else if ("function" ===
                    typeof this[e[b]]) this[e[b]](a[b]); "chart" !== b && -1 !== n(b, this.propsRequireUpdateSeries) && (k = !0)
                } a.colors && (this.options.colors = a.colors); a.plotOptions && v(!0, this.options.plotOptions, a.plotOptions); g(["xAxis", "yAxis", "series"], function (b) { a[b] && g(I(a[b]), function (a) { var c = d(a.id) && this.get(a.id) || this[b][0]; c && c.coll === b && c.update(a, !1) }, this) }, this); m && g(this.axes, function (a) { a.update({}, !1) }); k && g(this.series, function (a) { a.update({}, !1) }); a.loading && v(!0, this.options.loading, a.loading); b = h && h.width;
                h = h && h.height; f(b) && b !== this.chartWidth || f(h) && h !== this.chartHeight ? this.setSize(b, h) : H(c, !0) && this.redraw()
            }, setSubtitle: function (a) { this.setTitle(void 0, a) }
        }); l(c.prototype, {
            update: function (a, c, e, f) {
                function b() {
                    d.applyOptions(a); null === d.y && m && (d.graphic = m.destroy()); h(a, !0) && (m && m.element && a && a.marker && a.marker.symbol && (d.graphic = m.destroy()), a && a.dataLabels && d.dataLabel && (d.dataLabel = d.dataLabel.destroy())); k = d.index; g.updateParallelArrays(d, k); q.data[k] = h(q.data[k], !0) ? d.options : a; g.isDirty =
                    g.isDirtyData = !0; !g.fixedBox && g.hasCartesianSeries && (l.isDirtyBox = !0); "point" === q.legendType && (l.isDirtyLegend = !0); c && l.redraw(e)
                } var d = this, g = d.series, m = d.graphic, k, l = g.chart, q = g.options; c = H(c, !0); !1 === f ? b() : d.firePointEvent("update", { options: a }, b)
            }, remove: function (a, c) { this.series.removePoint(n(this, this.series.data), a, c) }
        }); l(e.prototype, {
            addPoint: function (a, c, e, f) {
                var b = this.options, d = this.data, g = this.chart, h = this.xAxis && this.xAxis.names, m = b.data, k, l, q = this.xData, r, n; c = H(c, !0); k = { series: this };
                this.pointClass.prototype.applyOptions.apply(k, [a]); n = k.x; r = q.length; if (this.requireSorting && n < q[r - 1]) for (l = !0; r && q[r - 1] > n;) r--; this.updateParallelArrays(k, "splice", r, 0, 0); this.updateParallelArrays(k, r); h && k.name && (h[n] = k.name); m.splice(r, 0, a); l && (this.data.splice(r, 0, null), this.processData()); "point" === b.legendType && this.generatePoints(); e && (d[0] && d[0].remove ? d[0].remove(!1) : (d.shift(), this.updateParallelArrays(k, "shift"), m.shift())); this.isDirtyData = this.isDirty = !0; c && g.redraw(f)
            }, removePoint: function (a,
            c, e) { var b = this, f = b.data, d = f[a], g = b.points, h = b.chart, m = function () { g && g.length === f.length && g.splice(a, 1); f.splice(a, 1); b.options.data.splice(a, 1); b.updateParallelArrays(d || { series: b }, "splice", a, 1); d && d.destroy(); b.isDirty = !0; b.isDirtyData = !0; c && h.redraw() }; r(e, h); c = H(c, !0); d ? d.firePointEvent("remove", null, m) : m() }, remove: function (a, c, e) { function b() { f.destroy(); d.isDirtyLegend = d.isDirtyBox = !0; d.linkSeries(); H(a, !0) && d.redraw(c) } var f = this, d = f.chart; !1 !== e ? t(f, "remove", null, b) : b() }, update: function (a,
            c) { var b = this, e = this.chart, f = this.userOptions, d = this.type, h = a.type || f.type || e.options.chart.type, k = m[d].prototype, q = ["group", "markerGroup", "dataLabelsGroup"], r; if (h && h !== d || void 0 !== a.zIndex) q.length = 0; g(q, function (a) { q[a] = b[a]; delete b[a] }); a = v(f, { animation: !1, index: this.index, pointStart: this.xData[0] }, { data: this.options.data }, a); this.remove(!1, null, !1); for (r in k) this[r] = void 0; l(this, m[h || d].prototype); g(q, function (a) { b[a] = q[a] }); this.init(e, a); e.linkSeries(); H(c, !0) && e.redraw(!1) }
        }); l(D.prototype,
        {
            update: function (a, c) { var b = this.chart; a = b.options[this.coll][this.options.index] = v(this.userOptions, a); this.destroy(!0); this.init(b, l(a, { events: void 0 })); b.isDirtyBox = !0; H(c, !0) && b.redraw() }, remove: function (a) { for (var b = this.chart, c = this.coll, e = this.series, f = e.length; f--;) e[f] && e[f].remove(!1); u(b.axes, this); u(b[c], this); b.options[c].splice(this.options.index, 1); g(b[c], function (a, b) { a.options.index = b }); this.destroy(); b.isDirtyBox = !0; H(a, !0) && b.redraw() }, setTitle: function (a, c) {
                this.update({ title: a },
                c)
            }, setCategories: function (a, c) { this.update({ categories: a }, c) }
        })
    })(M); (function (a) {
        var C = a.color, A = a.each, D = a.map, F = a.pick, k = a.Series, d = a.seriesType; d("area", "line", { softThreshold: !1, threshold: 0 }, {
            singleStacks: !1, getStackPoints: function () {
                var a = [], d = [], k = this.xAxis, t = this.yAxis, n = t.stacks[this.stackKey], f = {}, h = this.points, v = this.index, H = t.series, c = H.length, e, m = F(t.options.reversedStacks, !0) ? 1 : -1, r, I; if (this.options.stacking) {
                    for (r = 0; r < h.length; r++) f[h[r].x] = h[r]; for (I in n) null !== n[I].total && d.push(I);
                    d.sort(function (a, c) { return a - c }); e = D(H, function () { return this.visible }); A(d, function (b, g) { var h = 0, l, q; if (f[b] && !f[b].isNull) a.push(f[b]), A([-1, 1], function (a) { var h = 1 === a ? "rightNull" : "leftNull", k = 0, x = n[d[g + a]]; if (x) for (r = v; 0 <= r && r < c;) l = x.points[r], l || (r === v ? f[b][h] = !0 : e[r] && (q = n[b].points[r]) && (k -= q[1] - q[0])), r += m; f[b][1 === a ? "rightCliff" : "leftCliff"] = k }); else { for (r = v; 0 <= r && r < c;) { if (l = n[b].points[r]) { h = l[1]; break } r += m } h = t.toPixels(h, !0); a.push({ isNull: !0, plotX: k.toPixels(b, !0), plotY: h, yBottom: h }) } })
                } return a
            },
            getGraphPath: function (a) {
                var d = k.prototype.getGraphPath, g = this.options, t = g.stacking, n = this.yAxis, f, h, v = [], A = [], c = this.index, e, m = n.stacks[this.stackKey], r = g.threshold, I = n.getThreshold(g.threshold), b, g = g.connectNulls || "percent" === t, q = function (b, f, d) {
                    var g = a[b]; b = t && m[g.x].points[c]; var h = g[d + "Null"] || 0; d = g[d + "Cliff"] || 0; var k, l, g = !0; d || h ? (k = (h ? b[0] : b[1]) + d, l = b[0] + d, g = !!h) : !t && a[f] && a[f].isNull && (k = l = r); void 0 !== k && (A.push({ plotX: e, plotY: null === k ? I : n.getThreshold(k), isNull: g }), v.push({
                        plotX: e, plotY: null ===
                        l ? I : n.getThreshold(l), doCurve: !1
                    }))
                }; a = a || this.points; t && (a = this.getStackPoints()); for (f = 0; f < a.length; f++) if (h = a[f].isNull, e = F(a[f].rectPlotX, a[f].plotX), b = F(a[f].yBottom, I), !h || g) g || q(f, f - 1, "left"), h && !t && g || (A.push(a[f]), v.push({ x: f, plotX: e, plotY: b })), g || q(f, f + 1, "right"); f = d.call(this, A, !0, !0); v.reversed = !0; h = d.call(this, v, !0, !0); h.length && (h[0] = "L"); h = f.concat(h); d = d.call(this, A, !1, g); h.xMap = f.xMap; this.areaPath = h; return d
            }, drawGraph: function () {
                this.areaPath = []; k.prototype.drawGraph.apply(this);
                var a = this, d = this.areaPath, l = this.options, t = [["area", "highcharts-area", this.color, l.fillColor]]; A(this.zones, function (d, f) { t.push(["zone-area-" + f, "highcharts-area highcharts-zone-area-" + f + " " + d.className, d.color || a.color, d.fillColor || l.fillColor]) }); A(t, function (g) {
                    var f = g[0], h = a[f]; h ? (h.endX = d.xMap, h.animate({ d: d })) : (h = a[f] = a.chart.renderer.path(d).addClass(g[1]).attr({ fill: F(g[3], C(g[2]).setOpacity(F(l.fillOpacity, .75)).get()), zIndex: 0 }).add(a.group), h.isArea = !0); h.startX = d.xMap; h.shiftUnit = l.step ?
                    2 : 1
                })
            }, drawLegendSymbol: a.LegendSymbolMixin.drawRectangle
        })
    })(M); (function (a) {
        var C = a.pick; a = a.seriesType; a("spline", "line", {}, {
            getPointSpline: function (a, D, F) {
                var k = D.plotX, d = D.plotY, g = a[F - 1]; F = a[F + 1]; var u, l, t, n; if (g && !g.isNull && !1 !== g.doCurve && F && !F.isNull && !1 !== F.doCurve) {
                    a = g.plotY; t = F.plotX; F = F.plotY; var f = 0; u = (1.5 * k + g.plotX) / 2.5; l = (1.5 * d + a) / 2.5; t = (1.5 * k + t) / 2.5; n = (1.5 * d + F) / 2.5; t !== u && (f = (n - l) * (t - k) / (t - u) + d - n); l += f; n += f; l > a && l > d ? (l = Math.max(a, d), n = 2 * d - l) : l < a && l < d && (l = Math.min(a, d), n = 2 * d - l); n > F &&
                    n > d ? (n = Math.max(F, d), l = 2 * d - n) : n < F && n < d && (n = Math.min(F, d), l = 2 * d - n); D.rightContX = t; D.rightContY = n
                } D = ["C", C(g.rightContX, g.plotX), C(g.rightContY, g.plotY), C(u, k), C(l, d), k, d]; g.rightContX = g.rightContY = null; return D
            }
        })
    })(M); (function (a) { var C = a.seriesTypes.area.prototype, A = a.seriesType; A("areaspline", "spline", a.defaultPlotOptions.area, { getStackPoints: C.getStackPoints, getGraphPath: C.getGraphPath, setStackCliffs: C.setStackCliffs, drawGraph: C.drawGraph, drawLegendSymbol: a.LegendSymbolMixin.drawRectangle }) })(M);
    (function (a) {
        var C = a.animObject, A = a.color, D = a.each, F = a.extend, k = a.isNumber, d = a.merge, g = a.pick, u = a.Series, l = a.seriesType, t = a.stop, n = a.svg; l("column", "line", {
            borderRadius: 0, groupPadding: .2, marker: null, pointPadding: .1, minPointLength: 0, cropThreshold: 50, pointRange: null, states: { hover: { halo: !1, brightness: .1, shadow: !1 }, select: { color: "#cccccc", borderColor: "#000000", shadow: !1 } }, dataLabels: { align: null, verticalAlign: null, y: null }, softThreshold: !1, startFromThreshold: !0, stickyTracking: !1, tooltip: { distance: 6 }, threshold: 0,
            borderColor: "#ffffff"
        }, {
            cropShoulder: 0, directTouch: !0, trackerGroups: ["group", "dataLabelsGroup"], negStacks: !0, init: function () { u.prototype.init.apply(this, arguments); var a = this, d = a.chart; d.hasRendered && D(d.series, function (f) { f.type === a.type && (f.isDirty = !0) }) }, getColumnMetrics: function () {
                var a = this, d = a.options, k = a.xAxis, l = a.yAxis, c = k.reversed, e, m = {}, r = 0; !1 === d.grouping ? r = 1 : D(a.chart.series, function (b) {
                    var c = b.options, d = b.yAxis, f; b.type === a.type && b.visible && l.len === d.len && l.pos === d.pos && (c.stacking ? (e =
                    b.stackKey, void 0 === m[e] && (m[e] = r++), f = m[e]) : !1 !== c.grouping && (f = r++), b.columnIndex = f)
                }); var n = Math.min(Math.abs(k.transA) * (k.ordinalSlope || d.pointRange || k.closestPointRange || k.tickInterval || 1), k.len), b = n * d.groupPadding, q = (n - 2 * b) / r, d = Math.min(d.maxPointWidth || k.len, g(d.pointWidth, q * (1 - 2 * d.pointPadding))); a.columnMetrics = { width: d, offset: (q - d) / 2 + (b + ((a.columnIndex || 0) + (c ? 1 : 0)) * q - n / 2) * (c ? -1 : 1) }; return a.columnMetrics
            }, crispCol: function (a, d, g, k) {
                var c = this.chart, e = this.borderWidth, f = -(e % 2 ? .5 : 0), e = e % 2 ?
                .5 : 1; c.inverted && c.renderer.isVML && (e += 1); g = Math.round(a + g) + f; a = Math.round(a) + f; k = Math.round(d + k) + e; f = .5 >= Math.abs(d) && .5 < k; d = Math.round(d) + e; k -= d; f && k && (--d, k += 1); return { x: a, y: d, width: g - a, height: k }
            }, translate: function () {
                var a = this, d = a.chart, k = a.options, l = a.dense = 2 > a.closestPointRange * a.xAxis.transA, l = a.borderWidth = g(k.borderWidth, l ? 0 : 1), c = a.yAxis, e = a.translatedThreshold = c.getThreshold(k.threshold), m = g(k.minPointLength, 5), r = a.getColumnMetrics(), n = r.width, b = a.barW = Math.max(n, 1 + 2 * l), q = a.pointXOffset =
                r.offset; d.inverted && (e -= .5); k.pointPadding && (b = Math.ceil(b)); u.prototype.translate.apply(a); D(a.points, function (f) {
                    var h = g(f.yBottom, e), k = 999 + Math.abs(h), k = Math.min(Math.max(-k, f.plotY), c.len + k), l = f.plotX + q, r = b, t = Math.min(k, h), x, v = Math.max(k, h) - t; Math.abs(v) < m && m && (v = m, x = !c.reversed && !f.negative || c.reversed && f.negative, t = Math.abs(t - e) > m ? h - m : e - (x ? m : 0)); f.barX = l; f.pointWidth = n; f.tooltipPos = d.inverted ? [c.len + c.pos - d.plotLeft - k, a.xAxis.len - l - r / 2, v] : [l + r / 2, k + c.pos - d.plotTop, v]; f.shapeType = "rect"; f.shapeArgs =
                    a.crispCol.apply(a, f.isNull ? [f.plotX, c.len / 2, 0, 0] : [l, t, r, v])
                })
            }, getSymbol: a.noop, drawLegendSymbol: a.LegendSymbolMixin.drawRectangle, drawGraph: function () { this.group[this.dense ? "addClass" : "removeClass"]("highcharts-dense-data") }, pointAttribs: function (a, d) {
                var f = this.options, g = this.pointAttrToOptions || {}, c = g.stroke || "borderColor", e = g["stroke-width"] || "borderWidth", h = a && a.color || this.color, k = a[c] || f[c] || this.color || h, g = f.dashStyle, l; a && this.zones.length && (h = (h = a.getZone()) && h.color || a.options.color ||
                this.color); d && (d = f.states[d], l = d.brightness, h = d.color || void 0 !== l && A(h).brighten(d.brightness).get() || h, k = d[c] || k, g = d.dashStyle || g); a = { fill: h, stroke: k, "stroke-width": a[e] || f[e] || this[e] || 0 }; f.borderRadius && (a.r = f.borderRadius); g && (a.dashstyle = g); return a
            }, drawPoints: function () {
                var a = this, g = this.chart, l = a.options, n = g.renderer, c = l.animationLimit || 250, e; D(a.points, function (f) {
                    var h = f.graphic; k(f.plotY) && null !== f.y ? (e = f.shapeArgs, h ? (t(h), h[g.pointCount < c ? "animate" : "attr"](d(e))) : f.graphic = h = n[f.shapeType](e).attr({ "class": f.getClassName() }).add(f.group ||
                    a.group), h.attr(a.pointAttribs(f, f.selected && "select")).shadow(l.shadow, null, l.stacking && !l.borderRadius)) : h && (f.graphic = h.destroy())
                })
            }, animate: function (a) {
                var d = this, f = this.yAxis, g = d.options, c = this.chart.inverted, e = {}; n && (a ? (e.scaleY = .001, a = Math.min(f.pos + f.len, Math.max(f.pos, f.toPixels(g.threshold))), c ? e.translateX = a - f.len : e.translateY = a, d.group.attr(e)) : (e[c ? "translateX" : "translateY"] = f.pos, d.group.animate(e, F(C(d.options.animation), { step: function (a, c) { d.group.attr({ scaleY: Math.max(.001, c.pos) }) } })),
                d.animate = null))
            }, remove: function () { var a = this, d = a.chart; d.hasRendered && D(d.series, function (d) { d.type === a.type && (d.isDirty = !0) }); u.prototype.remove.apply(a, arguments) }
        })
    })(M); (function (a) { a = a.seriesType; a("bar", "column", null, { inverted: !0 }) })(M); (function (a) {
        var C = a.Series; a = a.seriesType; a("scatter", "line", {
            lineWidth: 0, marker: { enabled: !0 }, tooltip: {
                headerFormat: '\x3cspan style\x3d"color:{point.color}"\x3e\u25cf\x3c/span\x3e \x3cspan style\x3d"font-size: 0.85em"\x3e {series.name}\x3c/span\x3e\x3cbr/\x3e',
                pointFormat: "x: \x3cb\x3e{point.x}\x3c/b\x3e\x3cbr/\x3ey: \x3cb\x3e{point.y}\x3c/b\x3e\x3cbr/\x3e"
            }
        }, { sorted: !1, requireSorting: !1, noSharedTooltip: !0, trackerGroups: ["group", "markerGroup", "dataLabelsGroup"], takeOrdinalPosition: !1, kdDimensions: 2, drawGraph: function () { this.options.lineWidth && C.prototype.drawGraph.call(this) } })
    })(M); (function (a) {
        var C = a.pick, A = a.relativeLength; a.CenteredSeriesMixin = {
            getCenter: function () {
                var a = this.options, F = this.chart, k = 2 * (a.slicedOffset || 0), d = F.plotWidth - 2 * k, F = F.plotHeight -
                2 * k, g = a.center, g = [C(g[0], "50%"), C(g[1], "50%"), a.size || "100%", a.innerSize || 0], u = Math.min(d, F), l, t; for (l = 0; 4 > l; ++l) t = g[l], a = 2 > l || 2 === l && /%$/.test(t), g[l] = A(t, [d, F, u, g[2]][l]) + (a ? k : 0); g[3] > g[2] && (g[3] = g[2]); return g
            }
        }
    })(M); (function (a) {
        var C = a.addEvent, A = a.defined, D = a.each, F = a.extend, k = a.inArray, d = a.noop, g = a.pick, u = a.Point, l = a.Series, t = a.seriesType, n = a.setAnimation; t("pie", "line", {
            center: [null, null], clip: !1, colorByPoint: !0, dataLabels: {
                distance: 30, enabled: !0, formatter: function () {
                    return null === this.y ?
                    void 0 : this.point.name
                }, x: 0
            }, ignoreHiddenPoint: !0, legendType: "point", marker: null, size: null, showInLegend: !1, slicedOffset: 10, stickyTracking: !1, tooltip: { followPointer: !0 }, borderColor: "#ffffff", borderWidth: 1, states: { hover: { brightness: .1, shadow: !1 } }
        }, {
            isCartesian: !1, requireSorting: !1, directTouch: !0, noSharedTooltip: !0, trackerGroups: ["group", "dataLabelsGroup"], axisTypes: [], pointAttribs: a.seriesTypes.column.prototype.pointAttribs, animate: function (a) {
                var d = this, f = d.points, g = d.startAngleRad; a || (D(f, function (a) {
                    var c =
                    a.graphic, f = a.shapeArgs; c && (c.attr({ r: a.startR || d.center[3] / 2, start: g, end: g }), c.animate({ r: f.r, start: f.start, end: f.end }, d.options.animation))
                }), d.animate = null)
            }, updateTotals: function () { var a, d = 0, g = this.points, k = g.length, c, e = this.options.ignoreHiddenPoint; for (a = 0; a < k; a++) c = g[a], 0 > c.y && (c.y = null), d += e && !c.visible ? 0 : c.y; this.total = d; for (a = 0; a < k; a++) c = g[a], c.percentage = 0 < d && (c.visible || !e) ? c.y / d * 100 : 0, c.total = d }, generatePoints: function () { l.prototype.generatePoints.call(this); this.updateTotals() }, translate: function (a) {
                this.generatePoints();
                var d = 0, f = this.options, k = f.slicedOffset, c = k + (f.borderWidth || 0), e, m, l, n = f.startAngle || 0, b = this.startAngleRad = Math.PI / 180 * (n - 90), n = (this.endAngleRad = Math.PI / 180 * (g(f.endAngle, n + 360) - 90)) - b, q = this.points, t = f.dataLabels.distance, f = f.ignoreHiddenPoint, u, E = q.length, J; a || (this.center = a = this.getCenter()); this.getX = function (b, c) { l = Math.asin(Math.min((b - a[1]) / (a[2] / 2 + t), 1)); return a[0] + (c ? -1 : 1) * Math.cos(l) * (a[2] / 2 + t) }; for (u = 0; u < E; u++) {
                    J = q[u]; e = b + d * n; if (!f || J.visible) d += J.percentage / 100; m = b + d * n; J.shapeType =
                    "arc"; J.shapeArgs = { x: a[0], y: a[1], r: a[2] / 2, innerR: a[3] / 2, start: Math.round(1E3 * e) / 1E3, end: Math.round(1E3 * m) / 1E3 }; l = (m + e) / 2; l > 1.5 * Math.PI ? l -= 2 * Math.PI : l < -Math.PI / 2 && (l += 2 * Math.PI); J.slicedTranslation = { translateX: Math.round(Math.cos(l) * k), translateY: Math.round(Math.sin(l) * k) }; e = Math.cos(l) * a[2] / 2; m = Math.sin(l) * a[2] / 2; J.tooltipPos = [a[0] + .7 * e, a[1] + .7 * m]; J.half = l < -Math.PI / 2 || l > Math.PI / 2 ? 1 : 0; J.angle = l; c = Math.min(c, t / 5); J.labelPos = [a[0] + e + Math.cos(l) * t, a[1] + m + Math.sin(l) * t, a[0] + e + Math.cos(l) * c, a[1] + m + Math.sin(l) *
                    c, a[0] + e, a[1] + m, 0 > t ? "center" : J.half ? "right" : "left", l]
                }
            }, drawGraph: null, drawPoints: function () {
                var a = this, d = a.chart.renderer, g, k, c, e, m = a.options.shadow; m && !a.shadowGroup && (a.shadowGroup = d.g("shadow").add(a.group)); D(a.points, function (f) {
                    if (null !== f.y) {
                        k = f.graphic; e = f.shapeArgs; g = f.sliced ? f.slicedTranslation : {}; var h = f.shadowGroup; m && !h && (h = f.shadowGroup = d.g("shadow").add(a.shadowGroup)); h && h.attr(g); c = a.pointAttribs(f, f.selected && "select"); k ? k.setRadialReference(a.center).attr(c).animate(F(e, g)) : (f.graphic =
                        k = d[f.shapeType](e).addClass(f.getClassName()).setRadialReference(a.center).attr(g).add(a.group), f.visible || k.attr({ visibility: "hidden" }), k.attr(c).attr({ "stroke-linejoin": "round" }).shadow(m, h))
                    }
                })
            }, searchPoint: d, sortByAngle: function (a, d) { a.sort(function (a, f) { return void 0 !== a.angle && (f.angle - a.angle) * d }) }, drawLegendSymbol: a.LegendSymbolMixin.drawRectangle, getCenter: a.CenteredSeriesMixin.getCenter, getSymbol: d
        }, {
            init: function () {
                u.prototype.init.apply(this, arguments); var a = this, d; a.name = g(a.name, "Slice");
                d = function (d) { a.slice("select" === d.type) }; C(a, "select", d); C(a, "unselect", d); return a
            }, setVisible: function (a, d) { var f = this, h = f.series, c = h.chart, e = h.options.ignoreHiddenPoint; d = g(d, e); a !== f.visible && (f.visible = f.options.visible = a = void 0 === a ? !f.visible : a, h.options.data[k(f, h.data)] = f.options, D(["graphic", "dataLabel", "connector", "shadowGroup"], function (c) { if (f[c]) f[c][a ? "show" : "hide"](!0) }), f.legendItem && c.legend.colorizeItem(f, a), a || "hover" !== f.state || f.setState(""), e && (h.isDirty = !0), d && c.redraw()) },
            slice: function (a, d, l) { var f = this.series; n(l, f.chart); g(d, !0); this.sliced = this.options.sliced = a = A(a) ? a : !this.sliced; f.options.data[k(this, f.data)] = this.options; a = a ? this.slicedTranslation : { translateX: 0, translateY: 0 }; this.graphic.animate(a); this.shadowGroup && this.shadowGroup.animate(a) }, haloPath: function (a) { var d = this.shapeArgs; return this.sliced || !this.visible ? [] : this.series.chart.renderer.symbols.arc(d.x, d.y, d.r + a, d.r + a, { innerR: this.shapeArgs.r, start: d.start, end: d.end }) }
        })
    })(M); (function (a) {
        var C =
        a.addEvent, A = a.arrayMax, D = a.defined, F = a.each, k = a.extend, d = a.format, g = a.map, u = a.merge, l = a.noop, t = a.pick, n = a.relativeLength, f = a.Series, h = a.seriesTypes, v = a.stableSort, H = a.stop; a.distribute = function (a, d) {
            function c(a, b) { return a.target - b.target } var e, f = !0, b = a, h = [], k; k = 0; for (e = a.length; e--;) k += a[e].size; if (k > d) { v(a, function (a, b) { return (b.rank || 0) - (a.rank || 0) }); for (k = e = 0; k <= d;) k += a[e].size, e++; h = a.splice(e - 1, a.length) } v(a, c); for (a = g(a, function (a) { return { size: a.size, targets: [a.target] } }) ; f;) {
                for (e = a.length; e--;) f =
                a[e], k = (Math.min.apply(0, f.targets) + Math.max.apply(0, f.targets)) / 2, f.pos = Math.min(Math.max(0, k - f.size / 2), d - f.size); e = a.length; for (f = !1; e--;) 0 < e && a[e - 1].pos + a[e - 1].size > a[e].pos && (a[e - 1].size += a[e].size, a[e - 1].targets = a[e - 1].targets.concat(a[e].targets), a[e - 1].pos + a[e - 1].size > d && (a[e - 1].pos = d - a[e - 1].size), a.splice(e, 1), f = !0)
            } e = 0; F(a, function (a) { var c = 0; F(a.targets, function () { b[e].pos = a.pos + c; c += b[e].size; e++ }) }); b.push.apply(b, h); v(b, c)
        }; f.prototype.drawDataLabels = function () {
            var a = this, e = a.options,
            f = e.dataLabels, g = a.points, h, b, l = a.hasRendered || 0, n, v, E = t(f.defer, !0), J = a.chart.renderer; if (f.enabled || a._hasPointLabels) a.dlProcessOptions && a.dlProcessOptions(f), v = a.plotGroup("dataLabelsGroup", "data-labels", E && !l ? "hidden" : "visible", f.zIndex || 6), E && (v.attr({ opacity: +l }), l || C(a, "afterAnimate", function () { a.visible && v.show(!0); v[e.animation ? "animate" : "attr"]({ opacity: 1 }, { duration: 200 }) })), b = f, F(g, function (c) {
                var g, m = c.dataLabel, l, q, r = c.connector, x = !0, w, E = {}; h = c.dlOptions || c.options && c.options.dataLabels;
                g = t(h && h.enabled, b.enabled) && null !== c.y; if (m && !g) c.dataLabel = m.destroy(); else if (g) {
                    f = u(b, h); w = f.style; g = f.rotation; l = c.getLabelConfig(); n = f.format ? d(f.format, l) : f.formatter.call(l, f); w.color = t(f.color, w.color, a.color, "#000000"); if (m) D(n) ? (m.attr({ text: n }), x = !1) : (c.dataLabel = m = m.destroy(), r && (c.connector = r.destroy())); else if (D(n)) {
                        m = { fill: f.backgroundColor, stroke: f.borderColor, "stroke-width": f.borderWidth, r: f.borderRadius || 0, rotation: g, padding: f.padding, zIndex: 1 }; "contrast" === w.color && (E.color = f.inside ||
                        0 > f.distance || e.stacking ? J.getContrast(c.color || a.color) : "#000000"); e.cursor && (E.cursor = e.cursor); for (q in m) void 0 === m[q] && delete m[q]; m = c.dataLabel = J[g ? "text" : "label"](n, 0, -9999, f.shape, null, null, f.useHTML, null, "data-label").attr(m); m.addClass("highcharts-data-label-color-" + c.colorIndex + " " + (f.className || "")); m.css(k(w, E)); m.add(v); m.shadow(f.shadow)
                    } m && a.alignDataLabel(c, m, f, null, x)
                }
            })
        }; f.prototype.alignDataLabel = function (a, e, d, f, g) {
            var b = this.chart, c = b.inverted, h = t(a.plotX, -9999), m = t(a.plotY,
            -9999), l = e.getBBox(), n, r = d.rotation, u = d.align, v = this.visible && (a.series.forceDL || b.isInsidePlot(h, Math.round(m), c) || f && b.isInsidePlot(h, c ? f.x + 1 : f.y + f.height - 1, c)), A = "justify" === t(d.overflow, "justify"); v && (n = d.style.fontSize, n = b.renderer.fontMetrics(n, e).b, f = k({ x: c ? b.plotWidth - m : h, y: Math.round(c ? b.plotHeight - h : m), width: 0, height: 0 }, f), k(d, { width: l.width, height: l.height }), r ? (A = !1, c = b.renderer.rotCorr(n, r), c = { x: f.x + d.x + f.width / 2 + c.x, y: f.y + d.y + { top: 0, middle: .5, bottom: 1 }[d.verticalAlign] * f.height }, e[g ?
            "attr" : "animate"](c).attr({ align: u }), h = (r + 720) % 360, h = 180 < h && 360 > h, "left" === u ? c.y -= h ? l.height : 0 : "center" === u ? (c.x -= l.width / 2, c.y -= l.height / 2) : "right" === u && (c.x -= l.width, c.y -= h ? 0 : l.height)) : (e.align(d, null, f), c = e.alignAttr), A ? this.justifyDataLabel(e, d, c, l, f, g) : t(d.crop, !0) && (v = b.isInsidePlot(c.x, c.y) && b.isInsidePlot(c.x + l.width, c.y + l.height)), d.shape && !r && e.attr({ anchorX: a.plotX, anchorY: a.plotY })); v || (H(e), e.attr({ y: -9999 }), e.placed = !1)
        }; f.prototype.justifyDataLabel = function (a, d, f, g, h, b) {
            var c = this.chart,
            e = d.align, k = d.verticalAlign, m, l, n = a.box ? 0 : a.padding || 0; m = f.x + n; 0 > m && ("right" === e ? d.align = "left" : d.x = -m, l = !0); m = f.x + g.width - n; m > c.plotWidth && ("left" === e ? d.align = "right" : d.x = c.plotWidth - m, l = !0); m = f.y + n; 0 > m && ("bottom" === k ? d.verticalAlign = "top" : d.y = -m, l = !0); m = f.y + g.height - n; m > c.plotHeight && ("top" === k ? d.verticalAlign = "bottom" : d.y = c.plotHeight - m, l = !0); l && (a.placed = !b, a.align(d, null, h))
        }; h.pie && (h.pie.prototype.drawDataLabels = function () {
            var c = this, d = c.data, h, k = c.chart, l = c.options.dataLabels, b = t(l.connectorPadding,
            10), q = t(l.connectorWidth, 1), n = k.plotWidth, u = k.plotHeight, v, J = l.distance, w = c.center, C = w[2] / 2, G = w[1], D = 0 < J, p, y, H, O, B = [[], []], z, M, Q, R, T = [0, 0, 0, 0]; c.visible && (l.enabled || c._hasPointLabels) && (f.prototype.drawDataLabels.apply(c), F(d, function (a) { a.dataLabel && a.visible && (B[a.half].push(a), a.dataLabel._pos = null) }), F(B, function (d, e) {
                var f, m, q = d.length, r, t, x; if (q) for (c.sortByAngle(d, e - .5), 0 < J && (f = Math.max(0, G - C - J), m = Math.min(G + C + J, k.plotHeight), r = g(d, function (a) {
                if (a.dataLabel) return x = a.dataLabel.getBBox().height ||
                21, { target: a.labelPos[1] - f + x / 2, size: x, rank: a.y }
                }), a.distribute(r, m + x - f)), R = 0; R < q; R++) h = d[R], H = h.labelPos, p = h.dataLabel, Q = !1 === h.visible ? "hidden" : "inherit", t = H[1], r ? void 0 === r[R].pos ? Q = "hidden" : (O = r[R].size, M = f + r[R].pos) : M = t, z = l.justify ? w[0] + (e ? -1 : 1) * (C + J) : c.getX(M < f + 2 || M > m - 2 ? t : M, e), p._attr = { visibility: Q, align: H[6] }, p._pos = { x: z + l.x + ({ left: b, right: -b }[H[6]] || 0), y: M + l.y - 10 }, H.x = z, H.y = M, null === c.options.size && (y = p.width, z - y < b ? T[3] = Math.max(Math.round(y - z + b), T[3]) : z + y > n - b && (T[1] = Math.max(Math.round(z +
                y - n + b), T[1])), 0 > M - O / 2 ? T[0] = Math.max(Math.round(-M + O / 2), T[0]) : M + O / 2 > u && (T[2] = Math.max(Math.round(M + O / 2 - u), T[2])))
            }), 0 === A(T) || this.verifyDataLabelOverflow(T)) && (this.placeDataLabels(), D && q && F(this.points, function (a) {
                var b; v = a.connector; if ((p = a.dataLabel) && p._pos && a.visible) {
                    Q = p._attr.visibility; if (b = !v) a.connector = v = k.renderer.path().addClass("highcharts-data-label-connector highcharts-color-" + a.colorIndex).add(c.dataLabelsGroup), v.attr({ "stroke-width": q, stroke: l.connectorColor || a.color || "#666666" });
                    v[b ? "attr" : "animate"]({ d: c.connectorPath(a.labelPos) }); v.attr("visibility", Q)
                } else v && (a.connector = v.destroy())
            }))
        }, h.pie.prototype.connectorPath = function (a) { var c = a.x, d = a.y; return t(this.options.dataLabels.softConnector, !0) ? ["M", c + ("left" === a[6] ? 5 : -5), d, "C", c, d, 2 * a[2] - a[4], 2 * a[3] - a[5], a[2], a[3], "L", a[4], a[5]] : ["M", c + ("left" === a[6] ? 5 : -5), d, "L", a[2], a[3], "L", a[4], a[5]] }, h.pie.prototype.placeDataLabels = function () {
            F(this.points, function (a) {
                var c = a.dataLabel; c && a.visible && ((a = c._pos) ? (c.attr(c._attr),
                c[c.moved ? "animate" : "attr"](a), c.moved = !0) : c && c.attr({ y: -9999 }))
            })
        }, h.pie.prototype.alignDataLabel = l, h.pie.prototype.verifyDataLabelOverflow = function (a) {
            var c = this.center, d = this.options, f = d.center, g = d.minSize || 80, b, h; null !== f[0] ? b = Math.max(c[2] - Math.max(a[1], a[3]), g) : (b = Math.max(c[2] - a[1] - a[3], g), c[0] += (a[3] - a[1]) / 2); null !== f[1] ? b = Math.max(Math.min(b, c[2] - Math.max(a[0], a[2])), g) : (b = Math.max(Math.min(b, c[2] - a[0] - a[2]), g), c[1] += (a[0] - a[2]) / 2); b < c[2] ? (c[2] = b, c[3] = Math.min(n(d.innerSize || 0, b), b), this.translate(c),
            this.drawDataLabels && this.drawDataLabels()) : h = !0; return h
        }); h.column && (h.column.prototype.alignDataLabel = function (a, d, g, h, k) {
            var b = this.chart.inverted, c = a.series, e = a.dlBox || a.shapeArgs, l = t(a.below, a.plotY > t(this.translatedThreshold, c.yAxis.len)), m = t(g.inside, !!this.options.stacking); e && (h = u(e), 0 > h.y && (h.height += h.y, h.y = 0), e = h.y + h.height - c.yAxis.len, 0 < e && (h.height -= e), b && (h = { x: c.yAxis.len - h.y - h.height, y: c.xAxis.len - h.x - h.width, width: h.height, height: h.width }), m || (b ? (h.x += l ? 0 : h.width, h.width = 0) : (h.y +=
            l ? h.height : 0, h.height = 0))); g.align = t(g.align, !b || m ? "center" : l ? "right" : "left"); g.verticalAlign = t(g.verticalAlign, b || m ? "middle" : l ? "top" : "bottom"); f.prototype.alignDataLabel.call(this, a, d, g, h, k)
        })
    })(M); (function (a) {
        var C = a.Chart, A = a.each, D = a.pick, F = a.addEvent; C.prototype.callbacks.push(function (a) {
            function d() {
                var d = []; A(a.series, function (a) {
                    var g = a.options.dataLabels, k = a.dataLabelCollections || ["dataLabel"]; (g.enabled || a._hasPointLabels) && !g.allowOverlap && a.visible && A(k, function (g) {
                        A(a.points, function (a) {
                            a[g] &&
                            (a[g].labelrank = D(a.labelrank, a.shapeArgs && a.shapeArgs.height), d.push(a[g]))
                        })
                    })
                }); a.hideOverlappingLabels(d)
            } d(); F(a, "redraw", d)
        }); C.prototype.hideOverlappingLabels = function (a) {
            var d = a.length, g, k, l, t, n, f, h, v, C, c = function (a, c, d, f, b, g, h, k) { return !(b > a + d || b + h < a || g > c + f || g + k < c) }; for (k = 0; k < d; k++) if (g = a[k]) g.oldOpacity = g.opacity, g.newOpacity = 1; a.sort(function (a, c) { return (c.labelrank || 0) - (a.labelrank || 0) }); for (k = 0; k < d; k++) for (l = a[k], g = k + 1; g < d; ++g) if (t = a[g], l && t && l.placed && t.placed && 0 !== l.newOpacity && 0 !==
            t.newOpacity && (n = l.alignAttr, f = t.alignAttr, h = l.parentGroup, v = t.parentGroup, C = 2 * (l.box ? 0 : l.padding), n = c(n.x + h.translateX, n.y + h.translateY, l.width - C, l.height - C, f.x + v.translateX, f.y + v.translateY, t.width - C, t.height - C))) (l.labelrank < t.labelrank ? l : t).newOpacity = 0; A(a, function (a) { var c, d; a && (d = a.newOpacity, a.oldOpacity !== d && a.placed && (d ? a.show(!0) : c = function () { a.hide() }, a.alignAttr.opacity = d, a[a.isOld ? "animate" : "attr"](a.alignAttr, null, c)), a.isOld = !0) })
        }
    })(M); (function (a) {
        var C = a.addEvent, A = a.Chart, D = a.createElement,
        F = a.css, k = a.defaultOptions, d = a.defaultPlotOptions, g = a.each, u = a.extend, l = a.fireEvent, t = a.hasTouch, n = a.inArray, f = a.isObject, h = a.Legend, v = a.merge, H = a.pick, c = a.Point, e = a.Series, m = a.seriesTypes, r = a.svg, I; I = a.TrackerMixin = {
            drawTrackerPoint: function () {
                var a = this, c = a.chart, d = c.pointer, e = function (a) { for (var b = a.target, d; b && !d;) d = b.point, b = b.parentNode; if (void 0 !== d && d !== c.hoverPoint) d.onMouseOver(a) }; g(a.points, function (a) { a.graphic && (a.graphic.element.point = a); a.dataLabel && (a.dataLabel.element.point = a) });
                a._hasTracking || (g(a.trackerGroups, function (b) { if (a[b]) { a[b].addClass("highcharts-tracker").on("mouseover", e).on("mouseout", function (a) { d.onTrackerMouseOut(a) }); if (t) a[b].on("touchstart", e); a.options.cursor && a[b].css(F).css({ cursor: a.options.cursor }) } }), a._hasTracking = !0)
            }, drawTrackerGraph: function () {
                var a = this, c = a.options, d = c.trackByArea, e = [].concat(d ? a.areaPath : a.graphPath), f = e.length, h = a.chart, k = h.pointer, l = h.renderer, m = h.options.tooltip.snap, n = a.tracker, p, u = function () { if (h.hoverSeries !== a) a.onMouseOver() },
                v = "rgba(192,192,192," + (r ? .0001 : .002) + ")"; if (f && !d) for (p = f + 1; p--;) "M" === e[p] && e.splice(p + 1, 0, e[p + 1] - m, e[p + 2], "L"), (p && "M" === e[p] || p === f) && e.splice(p, 0, "L", e[p - 2] + m, e[p - 1]); n ? n.attr({ d: e }) : a.graph && (a.tracker = l.path(e).attr({ "stroke-linejoin": "round", visibility: a.visible ? "visible" : "hidden", stroke: v, fill: d ? v : "none", "stroke-width": a.graph.strokeWidth() + (d ? 0 : 2 * m), zIndex: 2 }).add(a.group), g([a.tracker, a.markerGroup], function (a) {
                    a.addClass("highcharts-tracker").on("mouseover", u).on("mouseout", function (a) { k.onTrackerMouseOut(a) });
                    c.cursor && a.css({ cursor: c.cursor }); if (t) a.on("touchstart", u)
                }))
            }
        }; m.column && (m.column.prototype.drawTracker = I.drawTrackerPoint); m.pie && (m.pie.prototype.drawTracker = I.drawTrackerPoint); m.scatter && (m.scatter.prototype.drawTracker = I.drawTrackerPoint); u(h.prototype, {
            setItemEvents: function (a, c, d) {
                var b = this, e = b.chart, f = "highcharts-legend-" + (a.series ? "point" : "series") + "-active"; (d ? c : a.legendGroup).on("mouseover", function () { a.setState("hover"); e.seriesGroup.addClass(f); c.css(b.options.itemHoverStyle) }).on("mouseout",
                function () { c.css(a.visible ? b.itemStyle : b.itemHiddenStyle); e.seriesGroup.removeClass(f); a.setState() }).on("click", function (b) { var c = function () { a.setVisible && a.setVisible() }; b = { browserEvent: b }; a.firePointEvent ? a.firePointEvent("legendItemClick", b, c) : l(a, "legendItemClick", b, c) })
            }, createCheckboxForItem: function (a) {
                a.checkbox = D("input", { type: "checkbox", checked: a.selected, defaultChecked: a.selected }, this.options.itemCheckboxStyle, this.chart.container); C(a.checkbox, "click", function (b) {
                    l(a.series || a, "checkboxClick",
                    { checked: b.target.checked, item: a }, function () { a.select() })
                })
            }
        }); k.legend.itemStyle.cursor = "pointer"; u(A.prototype, {
            showResetZoom: function () { var a = this, c = k.lang, d = a.options.chart.resetZoomButton, e = d.theme, f = e.states, g = "chart" === d.relativeTo ? null : "plotBox"; this.resetZoomButton = a.renderer.button(c.resetZoom, null, null, function () { a.zoomOut() }, e, f && f.hover).attr({ align: d.position.align, title: c.resetZoomTitle }).addClass("highcharts-reset-zoom").add().align(d.position, !1, g) }, zoomOut: function () {
                var a = this;
                l(a, "selection", { resetSelection: !0 }, function () { a.zoom() })
            }, zoom: function (a) { var b, c = this.pointer, d = !1, e; !a || a.resetSelection ? g(this.axes, function (a) { b = a.zoom() }) : g(a.xAxis.concat(a.yAxis), function (a) { var e = a.axis; c[e.isXAxis ? "zoomX" : "zoomY"] && (b = e.zoom(a.min, a.max), e.displayBtn && (d = !0)) }); e = this.resetZoomButton; d && !e ? this.showResetZoom() : !d && f(e) && (this.resetZoomButton = e.destroy()); b && this.redraw(H(this.options.chart.animation, a && a.animation, 100 > this.pointCount)) }, pan: function (a, c) {
                var b = this, d = b.hoverPoints,
                e; d && g(d, function (a) { a.setState() }); g("xy" === c ? [1, 0] : [1], function (c) { c = b[c ? "xAxis" : "yAxis"][0]; var d = c.horiz, f = a[d ? "chartX" : "chartY"], d = d ? "mouseDownX" : "mouseDownY", g = b[d], h = (c.pointRange || 0) / 2, k = c.getExtremes(), l = c.toValue(g - f, !0) + h, h = c.toValue(g + c.len - f, !0) - h, g = g > f; c.series.length && (g || l > Math.min(k.dataMin, k.min)) && (!g || h < Math.max(k.dataMax, k.max)) && (c.setExtremes(l, h, !1, !1, { trigger: "pan" }), e = !0); b[d] = f }); e && b.redraw(!1); F(b.container, { cursor: "move" })
            }
        }); u(c.prototype, {
            select: function (a, c) {
                var b =
                this, d = b.series, e = d.chart; a = H(a, !b.selected); b.firePointEvent(a ? "select" : "unselect", { accumulate: c }, function () { b.selected = b.options.selected = a; d.options.data[n(b, d.data)] = b.options; b.setState(a && "select"); c || g(e.getSelectedPoints(), function (a) { a.selected && a !== b && (a.selected = a.options.selected = !1, d.options.data[n(a, d.data)] = a.options, a.setState(""), a.firePointEvent("unselect")) }) })
            }, onMouseOver: function (a, c) {
                var b = this.series, d = b.chart, e = d.tooltip, f = d.hoverPoint; if (this.series) {
                    if (!c) {
                        if (f && f !== this) f.onMouseOut();
                        if (d.hoverSeries !== b) b.onMouseOver(); d.hoverPoint = this
                    } !e || e.shared && !b.noSharedTooltip ? e || this.setState("hover") : (this.setState("hover"), e.refresh(this, a)); this.firePointEvent("mouseOver")
                }
            }, onMouseOut: function () { var a = this.series.chart, c = a.hoverPoints; this.firePointEvent("mouseOut"); c && -1 !== n(this, c) || (this.setState(), a.hoverPoint = null) }, importEvents: function () {
                if (!this.hasImportedEvents) {
                    var a = v(this.series.options.point, this.options).events, c; this.events = a; for (c in a) C(this, c, a[c]); this.hasImportedEvents =
                    !0
                }
            }, setState: function (b, c) {
                var e = Math.floor(this.plotX), f = this.plotY, g = this.series, h = g.options.states[b] || {}, k = d[g.type].marker && g.options.marker, l = k && !1 === k.enabled, m = k && k.states && k.states[b] || {}, n = !1 === m.enabled, p = g.stateMarkerGraphic, q = this.marker || {}, t = g.chart, r = g.halo, v, z = k && g.markerAttribs; b = b || ""; if (!(b === this.state && !c || this.selected && "select" !== b || !1 === h.enabled || b && (n || l && !1 === m.enabled) || b && q.states && q.states[b] && !1 === q.states[b].enabled)) {
                    z && (v = g.markerAttribs(this, b)); if (this.graphic) this.state &&
                    this.graphic.removeClass("highcharts-point-" + this.state), b && this.graphic.addClass("highcharts-point-" + b), this.graphic.attr(g.pointAttribs(this, b)), v && this.graphic.animate(v, H(t.options.chart.animation, m.animation, k.animation)), p && p.hide(); else {
                        if (b && m) {
                            k = q.symbol || g.symbol; p && p.currentSymbol !== k && (p = p.destroy()); if (p) p[c ? "animate" : "attr"]({ x: v.x, y: v.y }); else k && (g.stateMarkerGraphic = p = t.renderer.symbol(k, v.x, v.y, v.width, v.height).add(g.markerGroup), p.currentSymbol = k); p && p.attr(g.pointAttribs(this,
                            b))
                        } p && (p[b && t.isInsidePlot(e, f, t.inverted) ? "show" : "hide"](), p.element.point = this)
                    } (e = h.halo) && e.size ? (r || (g.halo = r = t.renderer.path().add(z ? g.markerGroup : g.group)), a.stop(r), r[c ? "animate" : "attr"]({ d: this.haloPath(e.size) }), r.attr({ "class": "highcharts-halo highcharts-color-" + H(this.colorIndex, g.colorIndex) }), r.attr(u({ fill: this.color || g.color, "fill-opacity": e.opacity, zIndex: -1 }, e.attributes))) : r && r.animate({ d: this.haloPath(0) }); this.state = b
                }
            }, haloPath: function (a) {
                return this.series.chart.renderer.symbols.circle(Math.floor(this.plotX) -
                a, this.plotY - a, 2 * a, 2 * a)
            }
        }); u(e.prototype, {
            onMouseOver: function () { var a = this.chart, c = a.hoverSeries; if (c && c !== this) c.onMouseOut(); this.options.events.mouseOver && l(this, "mouseOver"); this.setState("hover"); a.hoverSeries = this }, onMouseOut: function () { var a = this.options, c = this.chart, d = c.tooltip, e = c.hoverPoint; c.hoverSeries = null; if (e) e.onMouseOut(); this && a.events.mouseOut && l(this, "mouseOut"); !d || a.stickyTracking || d.shared && !this.noSharedTooltip || d.hide(); this.setState() }, setState: function (a) {
                var b = this, c =
                b.options, d = b.graph, e = c.states, f = c.lineWidth, c = 0; a = a || ""; if (b.state !== a && (g([b.group, b.markerGroup], function (c) { c && (b.state && c.removeClass("highcharts-series-" + b.state), a && c.addClass("highcharts-series-" + a)) }), b.state = a, !e[a] || !1 !== e[a].enabled) && (a && (f = e[a].lineWidth || f + (e[a].lineWidthPlus || 0)), d && !d.dashstyle)) for (e = { "stroke-width": f }, d.attr(e) ; b["zone-graph-" + c];) b["zone-graph-" + c].attr(e), c += 1
            }, setVisible: function (a, c) {
                var b = this, d = b.chart, e = b.legendItem, f, h = d.options.chart.ignoreHiddenSeries,
                k = b.visible; f = (b.visible = a = b.options.visible = b.userOptions.visible = void 0 === a ? !k : a) ? "show" : "hide"; g(["group", "dataLabelsGroup", "markerGroup", "tracker", "tt"], function (a) { if (b[a]) b[a][f]() }); if (d.hoverSeries === b || (d.hoverPoint && d.hoverPoint.series) === b) b.onMouseOut(); e && d.legend.colorizeItem(b, a); b.isDirty = !0; b.options.stacking && g(d.series, function (a) { a.options.stacking && a.visible && (a.isDirty = !0) }); g(b.linkedSeries, function (b) { b.setVisible(a, !1) }); h && (d.isDirtyBox = !0); !1 !== c && d.redraw(); l(b, f)
            }, show: function () { this.setVisible(!0) },
            hide: function () { this.setVisible(!1) }, select: function (a) { this.selected = a = void 0 === a ? !this.selected : a; this.checkbox && (this.checkbox.checked = a); l(this, a ? "select" : "unselect") }, drawTracker: I.drawTrackerGraph
        })
    })(M); (function (a) {
        var C = a.Chart, A = a.each, D = a.inArray, F = a.isObject, k = a.pick, d = a.splat; C.prototype.setResponsive = function (a) { var d = this.options.responsive; d && d.rules && A(d.rules, function (d) { this.matchResponsiveRule(d, a) }, this) }; C.prototype.matchResponsiveRule = function (d, u) {
            var g = this.respRules, t = d.condition,
            n; n = t.callback || function () { return this.chartWidth <= k(t.maxWidth, Number.MAX_VALUE) && this.chartHeight <= k(t.maxHeight, Number.MAX_VALUE) && this.chartWidth >= k(t.minWidth, 0) && this.chartHeight >= k(t.minHeight, 0) }; void 0 === d._id && (d._id = a.uniqueKey()); n = n.call(this); !g[d._id] && n ? d.chartOptions && (g[d._id] = this.currentOptions(d.chartOptions), this.update(d.chartOptions, u)) : g[d._id] && !n && (this.update(g[d._id], u), delete g[d._id])
        }; C.prototype.currentOptions = function (a) {
            function g(a, k, f) {
                var h, l; for (h in a) if (-1 <
                D(h, ["series", "xAxis", "yAxis"])) for (a[h] = d(a[h]), f[h] = [], l = 0; l < a[h].length; l++) f[h][l] = {}, g(a[h][l], k[h][l], f[h][l]); else F(a[h]) ? (f[h] = {}, g(a[h], k[h] || {}, f[h])) : f[h] = k[h] || null
            } var k = {}; g(a, this.options, k); return k
        }
    })(M); return M
});