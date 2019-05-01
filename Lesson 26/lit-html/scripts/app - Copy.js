import { html, render } from './lit-html.js';

const helloTemplate = (data) => html`
<tr class="product-row" id="${data[i].ProductID}">
	<td><span id="name_${data[i].ProductID}">${data[i].ProductName}</span> (${data[i].QuantityPerUnit})</td>
	<td class="text-right">
		$<span id="price_${data[i].ProductID}">${data[i].UnitPrice}</span>
	</td>
	<td class="text-right">${data[i].UnitsInStock}</td>
</tr>
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
});



