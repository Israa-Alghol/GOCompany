const postSection = document.querySelector('#content');
const row = document.querySelector("#row");
let card = document.getElementById("row");
const cat = document.querySelector("#cat");
const cart = document.querySelector("#cart");
const datacart = document.querySelector("#datacart");

var filterInput = document.getElementById("cat");
var values = [];
var Id = [];
var ProId = [];
var input = "";

//console.log(cat);
async function getcat() {
    const responsecat = await fetch("https://localhost:44314/api/ProductApi/GetCat");
    const datacat = await responsecat.json();
    //console.log(datacat);

    datacat.forEach(c => {
        Id.push(c.id);
        values.push(c.type);
        
        cat.innerHTML +=
        `
        <option>${c.type}</option>
        `
    })
}
function MyData() {
    input = filterInput.value;
    //console.log(input);
    //console.log(Id);
    //console.log(values);
    for (i = 0; i < values.length; i++) {
        if (input == values[i]) {
            //console.log(input)
            //console.log()
            filterProducts(Id[i]).then;
        }
    }
}

async function get() {
    const response = await fetch("https://localhost:44314/api/ProductApi/GetAll");
    const data = await response.json();
    console.log(data);
    //input = filterInput.value;
                
    data.forEach(p => {
        ProId.push(p.id);

        row.innerHTML +=
            `    
                <div id ="product-id-${p.id}" class="col-4">
                <div class="card" style="width: 18rem;">
                    <img src= "/Uploads/${p.imageUrl}" class="card-img-top" width="250">
                    <div class="card-body">
                        <h2 class="card-title">${p.name}</h2>
                        <p class="card-text">${p.description}</p>
                        <button onclick="addToCart(${p.id},this)" class="btn btn-sm float-right btn-info">Add To Cart+</button>
                        <div class = "price-quantity">
                            <h5>${p.price}</h5>
                            <div class = "buttons">
                                <i onclick="decrement(${p.id})" class="fa fa-minus" aria-hidden="true"></i>
                                <div id=${p.id} class="quantity" width="12">0</div>
                                <i onclick="increment(${p.id})" class="fa fa-plus" aria-hidden="true"></i>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            `;
       
    })
    
}
//console.log(ProId);
async function filterProducts(i) {
    while (row.childNodes.length > 1)
        row.removeChild(row.lastChild);
    const response = await fetch(`https://localhost:44314/api/ProductApi/GetAll?categoryId=${i}`)
    const data = await response.json();
    //console.log(data);
    data.forEach(p => {

        row.innerHTML +=
            `
                <div class="col-4">
                <div class="card" style="width: 18rem;">
                    <img src= "/Uploads/${p.imageUrl}" class="card-img-top" width="250">
                    <div class="card-body">
                        <h5 class="card-title">${p.name}</h5>
                        <p class="card-text">${p.description}</p>
                        <button onclick="addToCart(${p.id})" class="btn btn-sm float-right btn-info">Add To Cart+</button>
                        <div class = "price-quantity">
                            <h5>${p.price}</h5>
                            <div class = "buttons">
                                <i class="bi bi-dash-lg text-dark"></i>
                                <div id=${p.id} class="quantity" width="12">0</div>
                                <i class ="bi bi-plus-lg"></i>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            `;
    })

}
let arr = [];
function addToCart(id) {
    arr.push(id);
    //console.log(n);
    localStorage.setItem('names', JSON.stringify(arr));
    let items = JSON.parse(localStorage.getItem('names'));
    //console.log(items);
    $(cart).html(items.length);
    
    
    getbyid(id).then;
    
}

let arrdata = [];
async function getbyid(i) {
    const responsecat = await fetch(`https://localhost:44314/api/ProductApi/Get?id=${i}`);
    const data = await responsecat.json();
    
    arrdata.push(data);
    console.log(arrdata);
}
let basket = [];
let increment = (id) => {
    let search = basket.find((x) => x.id === id);
    if (search === undefined) {
        basket.push({
            id: id,
            Item: 1,

        });
    }
    else {
        search.Item += 1;
    }

    //console.log(basket);
    update(id);
}
let decrement = (id) => {
    let search = basket.find((x) => x.id === id);
    if (search.Item === 0) return;
    else {
        search.Item -= 1;
    }

    //console.log(basket);
    update(id);
}
let update = (id) => {
    let search = basket.find((x) => x.id === id);
    //console.log(search.Item);
    document.getElementById(id).innerHTML = search.Item;
    calculation();
}

let calculation = (id) => {
    let cartIcon = document.getElementById("cartAmount");
    cartIcon.innerHTML = basket.map((x) => x.Item).reduce((x, y) => x + y, 0)

}



getcat().then();
get().then();
