import { Meta, StoryObj, moduleMetadata } from "@storybook/angular";
import { fn } from "@storybook/test";

import { WorkItemDisplayComponent } from "./work-item-display.component";
import { HttpClientModule } from "@angular/common/http"
import { WorkItemService } from "../../work-item.service";
const meta: Meta<WorkItemDisplayComponent> = {
    title: "work-item-display",
    component: WorkItemDisplayComponent,
    decorators: [
        moduleMetadata({
            imports: [HttpClientModule],

        })
    ]
}

export default meta;
type Story = StoryObj<WorkItemDisplayComponent>;
export const Default: Story = {
    args: {
        workItem: {
            id: 1,
            description: "Prepare presentation",
            isDone: false
        }
    }
}
