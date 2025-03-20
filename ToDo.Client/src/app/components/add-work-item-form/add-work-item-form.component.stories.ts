import { Meta, StoryObj, moduleMetadata, componentWrapperDecorator } from "@storybook/angular"
import { HttpClientModule } from "@angular/common/http";
import { fn } from "@storybook/test";

import { WorkItemService } from "../../work-item.service";
import { AddWorkItemFormComponent } from "./add-work-item-form.component";

const meta: Meta<AddWorkItemFormComponent> = {
    title: "add-work-item-form",
    component: AddWorkItemFormComponent,
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

type Story = StoryObj<AddWorkItemFormComponent>;
export const Default: Story = {
    args: {
        addWorkItem: fn()
    }
}
