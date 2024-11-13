import { DiscoveryListItemDto } from "../discovery/discovery-list-item-dto.model";

export interface Mission {
    id: number;
    name: string;
    date: Date;
    planetId: number;
    description: string;
    planetName: string;
    discoveries: DiscoveryListItemDto[];
  }
  