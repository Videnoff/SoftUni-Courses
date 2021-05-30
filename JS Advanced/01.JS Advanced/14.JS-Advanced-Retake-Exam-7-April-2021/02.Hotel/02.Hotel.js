class Hotel {
    constructor(name, capacity) {
        this.name = name;
        this.capacity = capacity;
        this.bookings = [];
        this.currentBookingNumber = 1;
        this.rooms = {
            single: Math.round(+this.capacity / 2),
            double: Math.round(+this.capacity * 0.3),
            maisonette: Math.round(+this.capacity * 0.2),
        };
    }

    get roomsPricing() {
        return {
            single: 50,
            double: 90,
            maisonette: 135,
        }
    }

    rentARoom(clientName, roomType, nights) {
        if (this.isAvailable(roomType)) {

            let booking = {
                clientName,
                roomType,
                nights: +nights,
                roomNumber: this.currentBookingNumber
            }
            this.bookings.push(booking);
            this.currentBookingNumber += 1;
            this.roomIncr(roomType);
            return `Enjoy your time here Mr./Mrs. ${clientName}. Your booking is ${this.currentBookingNumber - 1}.`
        } else {
            let output = `No ${roomType} rooms available!`;
            for (const room in this.rooms) {
                if (this.rooms.hasOwnProperty(room)) {
                    if (this.isAvailable(room)) {
                        output += ` Available ${room} rooms: ${this.rooms[room]}.`;
                    }
                }
            }

            return output;
        }
    }

    checkOut = (currentBookingNumber) => {
        const index = this.bookings.findIndex(function (i) {
            return i.roomNumber === currentBookingNumber;
        });
        if (index === -1) {
            return `The booking ${currentBookingNumber} is invalid.`
        }

        let booking = this.bookings.splice(+index, 1)[0];
        this.roomDecr(booking.roomType);

        let totalMoney = this.roomsPricing[booking.roomType] * booking.nights;

        if (!booking.hasOwnProperty('services')) {
            return `We hope you enjoyed your time here, Mr./Mrs. ${booking.clientName}. The total amount of money you have to pay is ${totalMoney} BGN.`
        }
    }

    report = () => {
        if (this.bookings.length === 0) {
            return `${this.name.toUpperCase()} DATABASE:\n--------------------\nThere are currently no bookings.`;
        } else {
            let output = `${this.name.toUpperCase()} DATABASE:\n--------------------\n`;
            let bookingsArray = [];
            for (const booking of this.bookings) {
                bookingsArray.push(`bookingNumber - ${booking.roomNumber}\nclientName - ${booking.clientName}\nroomType - ${booking.roomType}\nnights - ${booking.nights}${booking.hasOwnProperty('services') ? '\nservices: ' + booking.services.join(', ') : ''}`);
            }
            output += bookingsArray.join('\n----------\n');
            return output.trim();
        }
    }

    isAvailable(roomType) {
        return this.rooms[roomType] > 0;
    }

    roomIncr(room) {
        this.rooms[room] -= 1;
    }

    roomDecr(room) {
        this.rooms[room] += 1;
    }
}

/*
Input 1
 */

let hotel = new Hotel('HotUni', 10);

console.log(hotel.rentARoom('Peter', 'single', 4));
console.log(hotel.rentARoom('Robert', 'double', 4));
console.log(hotel.rentARoom('Geroge', 'maisonette', 6));

/*
Input 2
 */

// let hotel = new Hotel('HotUni', 10);

hotel.rentARoom('Peter', 'single', 4);
hotel.rentARoom('Robert', 'double', 4);
hotel.rentARoom('Geroge', 'maisonette', 6);

console.log(hotel.report());

