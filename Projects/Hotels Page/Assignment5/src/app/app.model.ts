export interface IHotel {
  hotel: [IRoomtypes, IEntries];
}

export interface IRoomtypes {
  roomtypes: IRoomtype[];
}

export interface IEntries {
  entries: IEntry[];
}

export interface IRoomtype {
  name: string;
}

export interface IEntry {
  hotelName: string;
  rating: number;
  city: string;
  thumbnail: string;
  guestrating: number;
  ratings: IRating;
  mapurl: string;
  filters: IFilter[];
  price: number;
}

export interface IRating {
  no: number;
  text: string;
}

export interface IFilter {
  name: string;
}