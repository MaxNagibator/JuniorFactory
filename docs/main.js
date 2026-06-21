const grid = document.getElementById("grid");

const io = new IntersectionObserver((entries) => {
  entries.forEach((e) => {
    if (e.isIntersecting) {
      const i = [...grid.children].indexOf(e.target);
      e.target.style.transitionDelay = Math.min(i, 9) * 55 + "ms";
      e.target.classList.add("in");
      io.unobserve(e.target);
    }
  });
}, { threshold: .15 });
[...grid.children].forEach(c => io.observe(c));

document.getElementById("year").textContent = new Date().getFullYear();
