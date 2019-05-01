let contentArea = document.querySelector("#content");

document.querySelector("button").addEventListener("click", () => {
	
	var URL = "http://localhost:55650/Product/FilterProducts?PriceFilter=5&SearchString=ch";
	$.getJSON(URL)
	.always(function (data, textStatus, statusObject) {
		if (statusObject.status == 200) {
			
		const template = `
			${data.map(i =>  `
				<tr class="product-row" id="${i.ProductID}">
					<td><span id="name_${i.ProductID}">${i.ProductName}</span> (${i.QuantityPerUnit})</td>
					<td class="text-right">
						$<span id="price_${i.ProductID}">${i.UnitPrice}</span>
					</td>
					<td class="text-right">${i.UnitsInStock}</td>
				</tr>
			`).join('')}
		`;			

				contentArea.innerHTML = template;

		}
	});
	
});



