import { ComponentProps} from "react";

const Container = (props: ComponentProps<"article"> ) => {
  return <article {...props} className={`mx-auto container ${props.className}`}>{props.children}</article>;
};

export default Container;
