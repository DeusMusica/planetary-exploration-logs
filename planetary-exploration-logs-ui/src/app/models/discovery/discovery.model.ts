import { MissionDto } from "../mission/mission-dto.model";
import { DiscoveryTypeDto } from "./discovery-type-dto.model";

export interface Discovery {
    id: number;
    missionId: number;
    discoveryTypeId: number;
    name: string;
    description: string;
    location: string;
    mission: MissionDto;
    discoveryType: DiscoveryTypeDto;
  }
  