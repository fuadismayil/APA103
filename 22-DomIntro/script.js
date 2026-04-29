document.title = "House Card";

let root = document.querySelector("#root");

document.body.style.margin = "0";
document.body.style.minHeight = "100vh";
document.body.style.display = "flex";
document.body.style.alignItems = "center";
document.body.style.justifyContent = "center";
document.body.style.backgroundColor = "#e8edf3";
document.body.style.fontFamily = "Arial, Helvetica, sans-serif";

let card = document.createElement("div");
card.style.width = "450px";
card.style.maxWidth = "94vw";
card.style.backgroundColor = "white";
card.style.borderRadius = "8px";
card.style.overflow = "hidden";
card.style.boxShadow = "0 2px 8px rgba(0, 0, 0, 0.10)";

let imageBox = document.createElement("div");
imageBox.style.height = "280px";
imageBox.style.backgroundImage = "url('https://images.unsplash.com/photo-1568605114967-8130f3a36994?auto=format&fit=crop&w=900&q=80')";
imageBox.style.backgroundSize = "cover";
imageBox.style.backgroundPosition = "center";
imageBox.style.position = "relative";

let heart = document.createElement("button");
heart.textContent = "\u2661";
heart.style.position = "absolute";
heart.style.top = "13px";
heart.style.right = "20px";
heart.style.border = "none";
heart.style.backgroundColor = "transparent";
heart.style.color = "white";
heart.style.fontSize = "40px";
heart.style.lineHeight = "38px";
heart.style.cursor = "pointer";
heart.style.padding = "0";

heart.addEventListener("click", function () {
    if (heart.textContent == "\u2661") {
        heart.textContent = "\u2665";
        heart.style.color = "#e74c3c";
    } else {
        heart.textContent = "\u2661";
        heart.style.color = "white";
    }
});

let info = document.createElement("div");
info.style.padding = "23px 20px 22px";

let type = document.createElement("p");
type.textContent = "DETACHED HOUSE \u2022 5Y OLD";
type.style.margin = "0 0 12px";
type.style.color = "#344a6b";
type.style.fontSize = "18px";
type.style.fontWeight = "700";

let price = document.createElement("h1");
price.textContent = "$750,000";
price.style.margin = "0 0 11px";
price.style.color = "#06152b";
price.style.fontSize = "34px";
price.style.fontWeight = "400";

let address = document.createElement("p");
address.textContent = "742 Evergreen Terrace";
address.style.margin = "0";
address.style.color = "#344a6b";
address.style.fontSize = "20px";

let features = document.createElement("div");
features.style.display = "flex";
features.style.borderTop = "1px solid #d9e0e8";
features.style.borderBottom = "1px solid #d9e0e8";

let bedrooms = document.createElement("div");
bedrooms.style.width = "50%";
bedrooms.style.display = "flex";
bedrooms.style.alignItems = "center";
bedrooms.style.gap = "14px";
bedrooms.style.padding = "19px 20px";
bedrooms.style.boxSizing = "border-box";

let bedIcon = document.createElement("div");
bedIcon.innerHTML = '<svg width="31" height="31" viewBox="0 0 32 32" fill="none" stroke="#71809a" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"><path d="M4 15V8h13v7"></path><path d="M17 15h7c2 0 4 2 4 4v5H4v-9h13z"></path><path d="M4 24v4"></path><path d="M28 24v4"></path><path d="M7 8V5h7v3"></path><path d="M16 8V5h7v5"></path></svg>';
bedIcon.style.height = "31px";

let bedText = document.createElement("p");
bedText.innerHTML = "<b>3</b> Bedrooms";
bedText.style.margin = "0";
bedText.style.color = "#344a6b";
bedText.style.fontSize = "20px";

let bathrooms = document.createElement("div");
bathrooms.style.width = "50%";
bathrooms.style.display = "flex";
bathrooms.style.alignItems = "center";
bathrooms.style.gap = "14px";
bathrooms.style.padding = "19px 20px";
bathrooms.style.boxSizing = "border-box";

let bathIcon = document.createElement("div");
bathIcon.innerHTML = '<svg width="31" height="31" viewBox="0 0 32 32" fill="none" stroke="#71809a" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"><path d="M5 17h22v3c0 4-3 7-7 7h-8c-4 0-7-3-7-7v-3z"></path><path d="M7 27l-2 3"></path><path d="M25 27l2 3"></path><path d="M22 14V8c0-2 1-3 3-3h1"></path><path d="M24 10h4"></path></svg>';
bathIcon.style.height = "31px";

let bathText = document.createElement("p");
bathText.innerHTML = "<b>2</b> Bathrooms";
bathText.style.margin = "0";
bathText.style.color = "#344a6b";
bathText.style.fontSize = "20px";

let realtorBox = document.createElement("div");
realtorBox.style.padding = "19px 20px";
realtorBox.style.backgroundColor = "#f8fafc";

let realtorTitle = document.createElement("p");
realtorTitle.textContent = "REALTOR";
realtorTitle.style.margin = "0 0 15px";
realtorTitle.style.color = "#66748b";
realtorTitle.style.fontSize = "15px";
realtorTitle.style.fontWeight = "700";

let person = document.createElement("div");
person.style.display = "flex";
person.style.alignItems = "center";
person.style.gap = "16px";

let avatar = document.createElement("img");
avatar.src = "https://images.unsplash.com/photo-1531123897727-8f129e1688ce?auto=format&fit=crop&w=120&q=80";
avatar.alt = "Realtor";
avatar.style.width = "50px";
avatar.style.height = "50px";
avatar.style.borderRadius = "50%";
avatar.style.objectFit = "cover";

let personText = document.createElement("div");

let name = document.createElement("h2");
name.textContent = "Tiffany Heffner";
name.style.margin = "0 0 4px";
name.style.color = "#06152b";
name.style.fontSize = "21px";
name.style.fontWeight = "700";

let phone = document.createElement("p");
phone.textContent = "(555) 555-4321";
phone.style.margin = "0";
phone.style.color = "#344a6b";
phone.style.fontSize = "18px";

bedrooms.appendChild(bedIcon);
bedrooms.appendChild(bedText);

bathrooms.appendChild(bathIcon);
bathrooms.appendChild(bathText);

features.appendChild(bedrooms);
features.appendChild(bathrooms);

info.appendChild(type);
info.appendChild(price);
info.appendChild(address);

personText.appendChild(name);
personText.appendChild(phone);

person.appendChild(avatar);
person.appendChild(personText);

realtorBox.appendChild(realtorTitle);
realtorBox.appendChild(person);

imageBox.appendChild(heart);

card.appendChild(imageBox);
card.appendChild(info);
card.appendChild(features);
card.appendChild(realtorBox);

root.appendChild(card);
