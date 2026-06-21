(function () {
  "use strict";
  var VIDEO_ID = LESSON.videoId, BLOCKS = LESSON.blocks || [], TITLE = LESSON.title;
  var facade = document.getElementById("facade"), playerEl = document.getElementById("player"),
      listEl = document.getElementById("tocList"), searchEl = document.getElementById("tocSearch"),
      countEl = document.getElementById("tocCount"), emptyEl = document.getElementById("tocEmpty"),
      npBox = document.getElementById("nowPlaying"), npTime = document.getElementById("npTime"),
      npTitle = document.getElementById("npTitle"), psState = document.getElementById("psState"),
      beltDone = document.getElementById("beltDone"),
      gaugeDone = document.getElementById("gaugeDone"), gaugeTotal = document.getElementById("gaugeTotal"),
      gaugeFill = document.getElementById("gaugeFill"), gaugeBar = document.getElementById("gaugeBar");
  var iframe = null, nodes = [];

  if (gaugeTotal) gaugeTotal.textContent = BLOCKS.length;
  if (gaugeBar) gaugeBar.setAttribute("aria-valuemax", BLOCKS.length);

  if (listEl) {
    var frag = document.createDocumentFragment();
    BLOCKS.forEach(function (blk, i) {
      var li = document.createElement("li"); li.className = "toc-item";
      var btn = document.createElement("button"); btn.type = "button"; btn.className = "toc-btn";
      btn.dataset.index = i;
      btn.setAttribute("aria-label", "Перемотать на " + blk.t + " — " + blk.title);
      var time = document.createElement("span"); time.className = "toc-time";
      var node = document.createElement("span"); node.className = "node"; node.setAttribute("aria-hidden", "true");
      var tt = document.createElement("span"); tt.textContent = blk.t;
      time.appendChild(node); time.appendChild(tt);
      var main = document.createElement("div"); main.className = "toc-main";
      var h = document.createElement("p"); h.className = "toc-title"; h.textContent = blk.title;
      var ul = document.createElement("ul"); ul.className = "toc-bullets";
      blk.b.forEach(function (text) { var bi = document.createElement("li"); bi.textContent = text; ul.appendChild(bi); });
      main.appendChild(h); main.appendChild(ul);
      btn.appendChild(time); btn.appendChild(main);
      btn.addEventListener("click", function () { play(i); });
      li.appendChild(btn); frag.appendChild(li); nodes.push(btn);
    });
    listEl.appendChild(frag);
  }

  function srcFor(start, autoplay) {
    var u = "https://www.youtube-nocookie.com/embed/" + VIDEO_ID + "?rel=0&modestbranding=1&playsinline=1&start=" + (start || 0);
    if (autoplay) u += "&autoplay=1";
    return u;
  }
  function ensureIframe(start) {
    if (!iframe) {
      iframe = document.createElement("iframe");
      iframe.setAttribute("title", TITLE + " — видео урока");
      iframe.setAttribute("allow", "accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share");
      iframe.setAttribute("allowfullscreen", "");
      iframe.setAttribute("referrerpolicy", "strict-origin-when-cross-origin");
      iframe.src = srcFor(start, true); playerEl.appendChild(iframe);
      if (facade) { facade.remove(); facade = null; }
    } else {
      iframe.src = srcFor(start, true);
    }
  }
  function updateGauge(i) {
    if (!gaugeFill) return;
    var done = i + 1, pct = (done / BLOCKS.length) * 100;
    gaugeFill.style.right = (100 - pct) + "%";
    if (gaugeDone) gaugeDone.textContent = done;
    if (gaugeBar) gaugeBar.setAttribute("aria-valuenow", done);
    if (beltDone) beltDone.style.setProperty("--belt", pct + "%");
  }
  function setActive(i) {
    nodes.forEach(function (n, idx) {
      n.classList.toggle("active", idx === i);
      n.classList.toggle("done", idx < i);
    });
    var btn = nodes[i];
    if (btn && typeof btn.scrollIntoView === "function") {
      var rm = window.matchMedia("(prefers-reduced-motion: reduce)").matches;
      try { btn.scrollIntoView({ block: "nearest", behavior: rm ? "auto" : "smooth" }); } catch (e) { btn.scrollIntoView(); }
    }
    var blk = BLOCKS[i];
    if (blk) {
      if (npBox) { npBox.hidden = false; npTime.textContent = blk.t; npTitle.textContent = blk.title; }
      if (psState) psState.textContent = blk.t + " · " + blk.title;
    }
    updateGauge(i);
  }
  function play(i) {
    var blk = BLOCKS[i];
    ensureIframe(blk ? blk.s : 0);
    if (blk) setActive(i);
  }
  if (facade) facade.addEventListener("click", function () { play(BLOCKS.length ? 0 : -1); });

  if (searchEl && listEl) {
    searchEl.addEventListener("input", function () {
      var q = searchEl.value.trim().toLowerCase();
      var items = listEl.querySelectorAll(".toc-item"), shown = 0;
      items.forEach(function (item, i) {
        var blk = BLOCKS[i], hay = (blk.title + " " + blk.b.join(" ") + " " + blk.t).toLowerCase();
        var match = !q || hay.indexOf(q) !== -1;
        item.classList.toggle("hide", !match); if (match) shown++;
      });
      if (countEl) countEl.textContent = shown;
      if (emptyEl) emptyEl.classList.toggle("show", shown === 0);
    });
  }

  document.getElementById("year").textContent = new Date().getFullYear();
})();
