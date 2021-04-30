function createCard(face, suit) {
    const validFaces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];

    let suitToString = {
        'S': '\u2660',
        'H': '\u2665',
        'D': '\u2666',
        'A': '\u2663',
    };

    if (validFaces.includes(face) === false) {
        throw new Error('Invalid face');
    } else if(Object.keys(suitToString).includes(suit) === false) {
        throw new Error('Invalid suit');
    }

    return {
        face,
        suit,
        toString() {
            return `${face}${suitToString[this.suit]}`;
        }
    }
}

createCard('A', 'S');
createCard('10', 'H');
createCard('1', 'C');