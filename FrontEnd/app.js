const SEARCH_INPUT = document.querySelector('.header__input');
const SEARCH_BUTTON = document.querySelector('.header__button');
const MAIN = document.querySelector('.main');
const TEXT_LINK = 'link';
const SITE_URL = 'http://localhost:5000/api/music';

async function sendRequest(model) {
    const response = await fetch(SITE_URL, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(model)
    });
    const data = await response.json();
    return data.message.body.track_list;
}

function createCard(data) {
    const card = document.createElement('div');
    card.classList.add('card', 'card__indent-bottom');

    const artist = document.createElement('div');
    artist.classList.add('card__artist', 'card__artist-indent');
    artist.textContent = data.artist_name;

    const track = document.createElement('div');
    track.classList.add('card__track', 'card__track-indent');
    track.textContent = data.track_name;

    const album = document.createElement('div');
    album.classList.add('card__album', 'card__album-indent');
    album.textContent = data.album_name;

    const linkWrapper = document.createElement('div');
    linkWrapper.classList.add('card__link-wrapper');

    const link = document.createElement('a');
    link.classList.add('card__link');
    link.textContent = TEXT_LINK;
    link.href = data.track_share_url;
    link.target = '_blank';

    linkWrapper.appendChild(link);

    card.appendChild(artist);
    card.appendChild(track);
    card.appendChild(album);
    card.appendChild(linkWrapper);

    console.log(card)
    return card;
}

function showCards(data) {
    MAIN.innerHTML = '';
    data.forEach(item => {
        console.log(item.track);
        const card = createCard(item.track);
        MAIN.appendChild(card);
    });
}

async function searchButton() {
    if (SEARCH_INPUT.value.length === 0) {
        alert('Please enter some value.');
        return;
    }

    const model = {
        userInput: SEARCH_INPUT.value,
    }
    SEARCH_INPUT.value = '';

    const result = await sendRequest(model);
    console.log(result);
    showCards(result);
}

function searchKey(event) {
    if (event.keyCode === 13) {
        event.preventDefault();
        searchButton();
    }
}

function main() {
    SEARCH_BUTTON.addEventListener('click', searchButton);
    SEARCH_INPUT.addEventListener('keyup', searchKey);
}

document.addEventListener('DOMContentLoaded', main);
