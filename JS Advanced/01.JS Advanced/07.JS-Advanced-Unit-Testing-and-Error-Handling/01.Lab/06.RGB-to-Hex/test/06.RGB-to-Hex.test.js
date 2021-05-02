const {expect} = require('chai');
const rgbToHexColor = require('../06.RGB-to-Hex');

describe('RGBtoHEX', function () {
    it('should convert black to hex', function () {
        expect(rgbToHexColor(0, 0, 0)).to.equal('#000000');
    });

    it('should convert white to hex', function () {
        expect(rgbToHexColor(255, 255, 255)).to.equal('#FFFFFF');
    });

    it('should convert red to hex', function () {
        expect(rgbToHexColor(255, 0, 0)).to.equal('#FF0000');
    });

    it('should convert blue to hex', function () {
        expect(rgbToHexColor(0, 255, 0)).to.equal('#00FF00');
    });

    it('should convert green to hex', function () {
        expect(rgbToHexColor(0, 0, 255)).to.equal('#0000FF');
    });

    it('should return undefined for (0, -1, 0)', function () {
        expect(rgbToHexColor(0, -1, 0)).to.equal(undefined);
    });

    it('should return undefined for (0, 0, -1)', function () {
        expect(rgbToHexColor(0, 0, -1)).to.equal(undefined);
    });

    it('should return undefined for string params', function () {
        expect(rgbToHexColor('a', 'a', 'a')).to.equal(undefined);
    });

    it('should return undefined for negative values', function () {
        expect(rgbToHexColor(-1, 0, 0)).to.equal(undefined);
    });

    it('should return undefined for values > 255', function () {
        expect(rgbToHexColor(256, 0, 0)).to.equal(undefined);
    });

    it('should convert (151, 104, 172) to hex', function () {
        expect(rgbToHexColor(151, 104, 172)).to.equal('#9768AC');
    });

    it('should convert (42, 173, 170) to hex', function () {
        expect(rgbToHexColor(42, 173, 170)).to.equal('#2AADAA');
    });
});