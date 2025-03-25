import { Meta, StoryObj, moduleMetadata, componentWrapperDecorator } from "@storybook/angular";
import { HttpClientModule } from "@angular/common/http";
import { fn } from "@storybook/test";

import { WorkItemService } from "../../work-item.service";
import { WorkItemDisplayComponent } from "./work-item-display.component";

const meta: Meta<WorkItemDisplayComponent> = {
    title: "work-item-display",
    component: WorkItemDisplayComponent,
    decorators: [
        moduleMetadata({
            imports: [HttpClientModule],
            providers: [WorkItemService]
        }),
        componentWrapperDecorator((story) => {
            return `<div style="background-color: lightgray; padding: 1em; font-size: 1.5em;">${story}</div>`
        })
    ]
};
export default meta;

type Story = StoryObj<WorkItemDisplayComponent>;
export const Default: Story = {
  args: {
    deleteWorkItem: fn(),
    updateWorkItem: fn(),
    workItem: {
        id: 1,
        description: "Prepare presentation",
        isDone: false,
        isMine: true
    }
}
}
