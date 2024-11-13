import { DiscoveryListItemDto } from "../discovery/discovery-list-item-dto.model";
import { Planet } from "../planet/planet.model";

export interface MissionListItemDto {
    id: number;
    name: string;
    date: Date;
    planetId: number;
    description: string;
    planet: Planet;
    discoveries: DiscoveryListItemDto[];
}
  