import { PublicMetrics } from "./public-metrics";

export interface StreamDataResponse {
  id: string;
  publicMetrics: PublicMetrics;
  text: string;
}
