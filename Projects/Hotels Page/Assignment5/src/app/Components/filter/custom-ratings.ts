export class Ratings {
    min: number;
    max: number;
    text: string;

    constructor(min: number, max: number, text: string) {
        this.min = min;
        this.max = max;
        this.text = text;
    }
}