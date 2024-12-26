namespace ProjetoSuporteWeb.wwwroot.js
{
    public class script
    {
        document.addEventListener("DOMContentLoaded", () => {
        const accordionButtons = document.querySelectorAll(".accordion-button");

        accordionButtons.forEach((button) => {
            button.addEventListener("click", () => {
                const content = document.querySelector(`#${button.getAttribute("aria-controls")}`);
                const isExpanded = button.getAttribute("aria-expanded") === "true";
                button.setAttribute("aria-expanded", !isExpanded);
                content.style.display = isExpanded ? "none" : "block";
            });
        });
    });



    }
}
