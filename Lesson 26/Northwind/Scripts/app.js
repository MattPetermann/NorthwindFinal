import { html, render } from './lit-html.js';

const helloTemplate = (data) => html`
  <div class="module">
    <h2>Hello ${data.name}!</h2>
    <p>${data.content}</p>
  </div>
`;

let data = {
  name: "Chris",
  content: "Just trying to figure stuff out."
}
let contentArea = document.querySelector("#content");

// renders the template
render(helloTemplate(data), contentArea);

document.querySelector("button").addEventListener("click", () => {
  // Maybe some Ajax call or whatever.
  data.name = "Sammy";

  // updates efficiently
  render(helloTemplate(data), contentArea);
  
  // updates less efficiently
  defineTemplate();
  regularContentArea.innerHTML = regularHTML;
});



// Regular
let regularHTML = ``;
function defineTemplate () {
  regularHTML = `
    <div class="module">
      <h2>Hello ${data.name}!</h2>
      <p>${data.content}</p>
    </div>
  `;
}
defineTemplate();
let regularContentArea = document.querySelector("#regular-content");
regularContentArea.innerHTML = regularHTML;


